    public static IDictionary<string, string> MergePathsOneToOne(
        IList<string> partialPaths, IList<string> fullPaths)
    {
        var sortedPartialPaths = partialPaths.OrderBy(p => p.Reverse()).ToList();
        var sortedFullPaths = fullPaths.OrderBy(p => p.Reverse()).ToList();
        return Enumerable
            .Range(0, sortedPartialPaths.Count)
            .ToDictionary(
                i => sortedPartialPaths[i], 
                i => sortedFullPaths[i]);
    }
