    public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
    {
        var skipOption = new SkipQueryOption("0", queryOptions.Context);
        typeof(ODataQueryOptions).GetProperty("Skip").SetValue(queryOptions, skipOption, null);
            
        return base.ApplyQuery(queryable, queryOptions);
    }
 
