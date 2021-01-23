    public static IEnumerable<string> GetAllMatchingPaths(string pattern)
    {
        char separator = Path.DirectorySeparatorChar;
        string[] parts = pattern.Split(separator);
        if (parts[0].Contains('*') || parts[0].Contains('?'))
            throw new ArgumentException("path root must not have a wildcard", nameof(parts));
        return GetAllMatchingPathsInternal(String.Join(separator.ToString(), parts.Skip(1)), parts[0]);
    }
    private static IEnumerable<string> GetAllMatchingPathsInternal(string pattern, string root)
    {
        char separator = Path.DirectorySeparatorChar;
        string[] parts = pattern.Split(separator);
        for (int i = 0; i < parts.Length; i++)
        {
            // if this part of the path is a wildcard that needs expanding
            if (parts[i].Contains('*') || parts[i].Contains('?'))
            {
                // create an absolute path up to the current wildcard and check if it exists
                var combined = root + separator + String.Join(separator.ToString(), parts.Take(i));
                if (!Directory.Exists(combined))
                    return new string[0];
                if (i == parts.Length - 1) // if this is the end of the path (a file name)
                {
                    return Directory.EnumerateFiles(combined, parts[i], SearchOption.TopDirectoryOnly);
                }
                else // if this is in the middle of the path (a directory name)
                {
                    var directories = Directory.EnumerateDirectories(combined, parts[i], SearchOption.TopDirectoryOnly);
                    var paths = directories.SelectMany(dir =>
                        GetAllMatchingPathsInternal(String.Join(separator.ToString(), parts.Skip(i + 1)), dir));
                    return paths;
                }
            }
        }
        // if pattern ends in an absolute path with no wildcards in the filename
        var absolute = root + separator + String.Join(separator.ToString(), parts);
        if (File.Exists(absolute))
            return new[] { absolute };
        return new string[0];
    }
