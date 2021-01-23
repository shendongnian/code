    public static IEnumerable<string> FallbackPaths(string path)
    {
        yield return path;
        var dir = Path.GetDirectoryName(path);
        var file = Path.GetFileNameWithoutExtension(path);
        var ext = Path.GetExtension(path);
        yield return Path.Combine(dir, file + " - Copy" + ext);
        for (var i = 2; ; i++)
        {
            yield return Path.Combine(dir, file + " - Copy " + i + ext);
        }
    }
    public static void SafeCopy(string src, string dest)
    {
        foreach (var path in FallbackPaths(dest))
        {
            if (!File.Exists(path))
            {
                File.Copy(src, path);
                break;
            }
        }
    }
