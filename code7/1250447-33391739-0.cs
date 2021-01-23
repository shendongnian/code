    static void MergingFiles(string outputFile, params string[] inputTxtDocs)
    {
        using (Stream outputStream = File.OpenWrite(outputFile))
        {
          foreach (string inputFile in inputTxtDocs)
          {
            using (Stream inputStream = File.OpenRead(inputFile))
            {
              inputStream.CopyTo(outputStream);
            }
          }
        }
    }
