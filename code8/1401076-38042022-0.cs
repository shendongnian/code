    public static void UnionFiles(string folderPath, string outputFilePath)
    {
        using (var writer = new StreamWriter(outputFilePath))
        {
            foreach (string filePath in Directory
                        .EnumerateFiles(folderPath, "*.txt")
                        .OrderBy(x => Path.GetFileNameWithoutExtension(x)))
            {
                writer.Write(File.ReadAllText(filePath));
            }
        }
    }
