    public static IDictionary<string, string> MergePaths(
        IList<string> partialPaths, IList<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .ToList();
        
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .ToList();
        var index = 0;
        return sortedPartialPaths.ToDictionary(
            pp => pp.Original,
            pp =>
                {
                    if (index < 0)
                    {
                        return null;
                    }
                    index = sortedFullPaths.FindIndex(
                        index,
                        fp => fp.Reverse.CompareTo(pp.Reverse) > -1);
                    if (index < 0)
                    {
                        return null;
                    }
                    var fullPath = sortedFullPaths[index];
                    return fullPath.Original.EndsWith(pp.Original)
                        ? fullPath.Original
                        : null;
                });
    }
