    public long GetDirectorySize(string path)
    {
        var dirInfo = new DirectoryInfo(path);
        long totalSize = 0;
        foreach (var fileInfo in dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
        {
            totalSize += fileInfo.Length;
        }
        return totalSize;
    }
