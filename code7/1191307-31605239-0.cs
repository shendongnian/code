    private static bool FilesPresent()
    {
        IEnumerable<string> dirs = Directory.EnumerateDirectories(dataFileDirectoryPath, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string d in dirs)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(d, "*.*", SearchOption.AllDirectories);
            if (files.Any()) { return true; }
        }
        return false;
    }
