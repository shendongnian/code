    public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
    {
        var parser = typeof(ODataQueryOptions).GetField("_queryOptionParser", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(queryOptions) as ODataQueryOptionParser;
        typeof(ODataQueryOptions).GetProperty("Skip").SetValue(queryOptions, new SkipQueryOption("0", queryOptions.Context, parser), null);
        typeof(ODataQueryOptions).GetProperty("Top").SetValue(queryOptions, new TopQueryOption("0", queryOptions.Context, parser), null);
        typeof(ODataQueryOptions).GetProperty("OrderBy").SetValue(queryOptions, new OrderByQueryOption("0", queryOptions.Context, parser), null);
        return base.ApplyQuery(queryable, queryOptions);
    }
