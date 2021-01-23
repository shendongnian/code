    public static IDictionary<string, string> MergePaths(
        IEnumerable<string> partialPaths, IEnumerable<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .ToList();
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .Select((p, i) => new { p.Original, p.Reverse, Index = i })
            .ToList();
        var lastFullPathIndex = 0;
        return sortedPartialPaths.ToDictionary(
            partialPath => partialPath.Original,
            partialPath => 
            {
                var matchedFullPath = sortedFullPaths
                    .Skip(lastFullPathIndex)
                    .SkipWhile(fullPath => fullPath.Reverse.CompareTo(partialPath.Reverse) < 1)
                    .TakeWhile(fullPath => fullPath.Reverse.StartsWith(partialPath.Reverse))
                    .FirstOrDefault();
                lastFullPathIndex = matchedFullPath?.Index ?? lastFullPathIndex;
                return matchedFullPath?.Original;
            });
    }
