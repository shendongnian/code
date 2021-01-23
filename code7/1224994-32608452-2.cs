    public string[] SearchFiles(string query)
    {
        if (IsDirectory(query))
            return Directory.GetFiles(query, "*.*");
        return Directory.GetFiles(
            Path.GetDirectoryName(query),
            Path.GetFileName(query));
    }
    private static bool IsDirectory(string path)
    {
        if (String.IsNullOrWhiteSpaces(path))
            return false;
        if (path[path.Length - 1] == Path.DirectorySeparatorChar)
            return true;
        if (path[path.Length - 1] == Path.AltDirectorySeparatorChar)
            return true;
        if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            return false;
        return Directory.Exists(path);
    }
