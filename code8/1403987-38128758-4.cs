    public static IDictionary<string, string> MergePaths(
        IEnumerable<string> partialPaths, IEnumerable<string> fullPaths)
    {
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse);
        var mergedPaths = new Dictionary<string, string>();
        foreach (var partialPath in 
            partialPaths.Select(p => new { Original = p, Reverse = p.Reverse() }))
        {
            var matchingFullPath = sortedFullPaths
                .SkipWhile(fullPath => fullPath.Reverse.CompareTo(partialPath.Reverse) < 1)
                .TakeWhile(fullPath => fullPath.Reverse.StartsWith(partialPath.Reverse))
                .FirstOrDefault();
            if (matchingFullPath != null && !mergedPaths.ContainsKey(partialPath.Original))
            {
                mergedPaths[partialPath.Original] = matchingFullPath.Original;
            }
        }
        return mergedPaths;
    }
