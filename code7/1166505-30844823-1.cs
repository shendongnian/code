    private static long GetDirectorySize(string folderPath)
    {
        try
        {
           DirectoryInfo di = new DirectoryInfo(folderPath);
           return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }
        catch
        {
           // If you get Access denied error handle it here
           return -1;
        }
    }
