    public static List<string> GetFilePaths(string dir)
    {
        var result = new List<string>;
        var dirs = Directory.GetDirectories(dir);
        if (dirs.Count() > 0)
        {
            foreach (var pwd in dirs)
            {
                result.AddRange(GetFilePaths(pwd));
            }
        }
        result.AddRange(GetFilePaths(dir));
        return result;
    }
