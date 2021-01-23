    public string FindFirstFile(string dir, string file)
    {
        if (System.IO.File.Exists(Path.Combine(dir, file)))
        {
            return Path.Combine(dir, file);
        }
        foreach (var subDir in System.IO.Directory.EnumerateDirectories(dir))
        {
            var result = FindFirstFile(subDir, file);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }
