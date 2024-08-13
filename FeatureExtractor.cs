using System;
using System.IO;

using chapter5test.Common;
using chapter5test.ML.Base;
using chapter5test.ML.Objects;

namespace chapter5test.ML
{
    public class FeatureExtractor : BaseML
    {
        private void ExtractFolder(string folderPath, string outputFile)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"{folderPath} does not exist");

                return;
            }

            var files = Directory.GetFiles(folderPath);

            using (var streamWriter =
                new StreamWriter(Path.Combine(AppContext.BaseDirectory, $"../../../Data/{outputFile}")))
            {
                foreach (var file in files)
                {
                    var extractedData = new FileData(File.ReadAllBytes(file), file);

                    streamWriter.WriteLine(extractedData.ToString());
                }
            }

            Console.WriteLine($"Extracted {files.Length} to {outputFile}");
        }

        public void Extract(string trainingPath, string testPath)
        {
            ExtractFolder(trainingPath, Constants.SAMPLE_DATA);
            ExtractFolder(testPath, Constants.TEST_DATA);
        }
    }
}