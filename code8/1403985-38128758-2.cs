    public static IDictionary<string, string> MergePaths(
        IEnumerable<string> partialPaths, IEnumerable<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse);
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse);
        return sortedPartialPaths.ToDictionary(
            partialPath => partialPath.Original,
            partialPath => sortedFullPaths
                .SkipWhile(fullPath => fullPath.Reverse.CompareTo(partialPath.Reverse) < 1)
                .TakeWhile(fullPath => fullPath.Reverse.StartsWith(partialPath.Reverse))
                .First()?.Original);
    }
