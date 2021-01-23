    public IEnumerable<Thing> Get(ODataQueryOptions<Thing> opts)
    {
        var filter = opts.Filter.FilterClause.Expression;
        var ordering = opts.OrderBy.OrderByClause.Expression;
        var skip = opts.Skip.Value;
        var top = opts.Top.Value;
        return this.Repository.GetThings(key, filter, ordering, skip, top);
    }
