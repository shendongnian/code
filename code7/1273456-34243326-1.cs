    public IQueryable<Thing> Foo(MyContext db)
    {
        var rootQuery = db.People.Where(x => x.City != null && x.State != null);
        var groupedQuery = rootQuery.GroupBy("new ( it.City, it.State )", "it", new []{"City", "State"});
        var finalLogicalQuery = groupedQuery.Select<Thing>("new ( Count() as TotalNumber, Key.City as City, Key.State as State )");  // IQueryable<Thing>
        var executionDeferredTypedThings = finalLogicalQuery.Take(10);
        return executionDeferredTypedThings;
    }
