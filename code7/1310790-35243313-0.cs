    static void Main(string[] args)
    {
        var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var path = Path.Combine(desktop, "A");
        var outPath = Path.Combine(desktop, "B");
        Copy(20, "file", path, outPath, x => x.LastWriteTimeUtc);
    }
    static void Copy<T>(int count, string filter, string inputPath, string outputPath, Func<FileInfo, T> order)
    {
        new DirectoryInfo(inputPath).GetFiles()
            .OrderBy(order)
            .Where(file => file.Name.Contains(filter))
            .Take(count)
            .ToList()
            .ForEach(file => File.Copy(file.FullName, Path.Combine(outputPath, file.Name), true));
    }
