    public static void UnionFiles(string folderPath, string outputFilePath)
    {
        var union = Enumerable.Empty<string>();
        foreach (string filePath in Directory
                    .EnumerateFiles(folderPath, "*.txt")
                    .OrderBy(x => Path.GetFileNameWithoutExtension(x)))
        {
                union = union.Union(File.ReadAllLines(filePath));
        }
        File.WriteAllLines(outputFilePath, union);
    }
