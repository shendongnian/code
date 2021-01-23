    private static long GetFolderSize(string sourceDir)
    {
        long size = 0;
        string[] fileEntries = Directory.GetFiles(sourceDir);
        foreach (string fileName in fileEntries)
        {
            Interlocked.Add(ref size, (new FileInfo(fileName)).Length);
        }
        var subFolders = Directory.EnumerateDirectories(sourceDir);
        var tasks = subFolders.Select(folder => Task.Factory.StartNew(() =>
        {
            if ((File.GetAttributes(folder) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
            {
                Interlocked.Add(ref size, (GetFolderSize(folder)));
                return size;
            }
            return 0;
        }));
        Task.WaitAll(tasks.ToArray());
        return size;
    }
