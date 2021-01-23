        static void SaveFileListingToText(string folder, string outputTxtFilePath)
        {
            string[] files = System.IO.Directory.GetFiles(folder);
            System.IO.File.WriteAllLines(outputTxtFilePath, files);
        }
