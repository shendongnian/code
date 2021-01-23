    public static IEnumerable<FileInfo> GetLatestFiles(string path)
    {
        return new DirectoryInfo(path)
                .GetFiles("*.log")
                .GroupBy(f => f.LastWriteTime.Date)
                .OrderByDescending(g => g.Key) // Order the groups by date (desc)
                .First(); // Just return the most recent group
    }
