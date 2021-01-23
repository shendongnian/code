    public static IDictionary<string, string> MergePaths(
        IEnumerable<string> partialPaths, IEnumerable<string> fullPaths)
    {
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse);
        return partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .ToDictionary(
                partialPath => partialPath.Original,
                partialPath => sortedFullPaths
                    .SkipWhile(fullPath => fullPath.Reverse.CompareTo(partialPath.Reverse) < 1)
                    .TakeWhile(fullPath => fullPath.Reverse.StartsWith(partialPath.Reverse))
                    .FirstOrDefault()?.Original);
    }
