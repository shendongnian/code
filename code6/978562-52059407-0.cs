    public static string GetLongestCommonPrefix(params string[] s)
    {
        return GetLongestCommonPrefix((ICollection<string>)s);
    }
    public static string GetLongestCommonPrefix(ICollection<string> paths)
    {
        if (paths == null || paths.Count == 0)
            return null;
        
        if (paths.Count == 1)
            return paths.First();
        var allSplittedPaths = paths.Select(p => p.Split('\\')).ToList();
        var min = allSplittedPaths.Min(a => a.Length);
        var i = 0;
        for (i = 0; i < min; i++)
        {
            var reference = allSplittedPaths[0][i];
            if (allSplittedPaths.Any(a => !string.Equals(a[i], reference, StringComparison.OrdinalIgnoreCase)))
            {
                break;
            }
        }
        return string.Join("\\", allSplittedPaths[0].Take(i));
    }
