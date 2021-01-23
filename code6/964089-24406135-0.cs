    public static IEnumerable<FileInfo> GetLatestFiles(string path)
    {
        return new DirectoryInfo(path)
                .GetFiles("*.log")
                .GroupBy(f => f.Extension)
                .Select(g => g.OrderByDescending(f => f.LastWriteTime
                .Date
                .ToShortDateString()));
    }
