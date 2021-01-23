         private static void CombineMultipleFilesIntoSingleFile(string inputDirectoryPath, string inputFileNamePattern, string outputFilePath)
    {
        string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
        Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
        using (var outputStream = File.Create(outputFilePath))
        {
            foreach (var inputFilePath in inputFilePaths)
            {
                using (var inputStream = File.OpenRead(inputFilePath))
                {
                    // Buffer size can be passed as the second argument.
                    inputStream.CopyTo(outputStream);
                }
                Console.WriteLine("The file {0} has been processed.", inputFilePath);
            }
        }
    }
