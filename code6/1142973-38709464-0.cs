    [EnableQuery]
    public IQueryable<FooBarBaz> Get(ODataQueryOptions<FooBarBaz> queryOptions, bool distinct)
    {
        DbQuery<FooBarBaz> query = Repository;
        query = this.ApplyUserPolicy(query);
        return Ok(query);
    }
