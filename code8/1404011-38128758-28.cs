    public static IDictionary<string, string> MergePathsOneToOne(
        IList<string> partialPaths, IList<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .Select((p, i) => new { p.Original, p.Reverse, Index = i })
            .ToList();
        
        var sortedFullPaths = fullPaths
            .Select(p => new { Original = p, Reverse = p.Reverse() })
            .OrderBy(p => p.Reverse)
            .ToList();
        
        return sortedPartialPaths.ToDictionary(
            partialPath => partialPath.Original,
            partialPath => sortedFullPaths[partialPath.Index].Original);
    }
