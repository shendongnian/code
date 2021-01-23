    public static IQueryable GroupByColumns(this IQueryable source,
        bool includeVariety = false,
        bool includeCategory = false)
    {
        var columns = new List<string>();
        if (includeVariety) columns.Add("Variety");
        if (includeCategory) columns.Add("Category");
        return source.GroupBy($"new({String.Join(",", columns)})", "it");
    }
