    public static string Combine(string path1, string path2)
    {
        if (path1 == null || path2 == null)
        {
            throw new ArgumentNullException((path1 == null) ? "path1" : "path2");
        }
        Path.CheckInvalidPathChars(path1, false);
        Path.CheckInvalidPathChars(path2, false);
        return Path.CombineNoChecks(path1, path2);
    }
    private static string CombineNoChecks(string path1, string path2)
    {
        if (path2.Length == 0)
        {
            return path1;
        }
        if (path1.Length == 0)
        {
            return path2;
        }
        if (Path.IsPathRooted(path2))
        {
            return path2;
        }
        char c = path1[path1.Length - 1];
        if (c != Path.DirectorySeparatorChar && c != Path.AltDirectorySeparatorChar && c != Path.VolumeSeparatorChar)
        {
            return path1 + Path.DirectorySeparatorChar + path2;
        }
        return path1 + path2;
    }
