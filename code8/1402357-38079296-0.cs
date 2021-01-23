    public static void UnionFiles()
    { 
        string folderPath =     Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "http");
        string outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "http\\union.dat");
        var union =new List<string>();
        foreach (string filePath in Directory
                .EnumerateFiles(folderPath, "*.txt")
                .OrderBy(x => Path.GetFileNameWithoutExtension(x)))
        {
             var filter = File.ReadAllLines(filePath).Where(x => !union.Contains(x)).ToList();
        union.AddRange(filter);
        }
        File.WriteAllLines(outputFilePath, union);
    }
