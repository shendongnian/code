    public static long FileSize(string path)
    {
        var di = new DirectoryInfo(path);
        var allFiles = di.EnumerateFiles(); // Enter your filter "*.SS" or whatever
        var beforeDate = DateTime.Now.AddMonths(-2);
        var olderThan2Months = allFiles.Where(x => x.CreationTime < beforeDate);
        return olderThan2Months.Sum(x => x.Length);
    }
