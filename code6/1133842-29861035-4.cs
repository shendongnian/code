    public static bool HasEqualSizeSubsets<T>(
        IEnumerable<T> items, params Func<T, bool>[] filters)
    {
        var indexedFilters = filters
            .Select((filter, index) => new { Filter = filter, Index = index })
            .ToArray(); // to avoid repeated object allocations later
        IEnumerable<int> subsetSizes = items
            .SelectMany(item => indexedFilters
                .Where(indexedFilter => indexedFilter.Filter(item))
                .Select(indexedFilter => indexedFilter.Index))
            .GroupBy(index => index)
            .Select(grouping => grouping.Count());
        return subsetSizes.Distinct().Count() == 1;
    }
