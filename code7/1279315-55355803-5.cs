    [EnableQuery()] // Enables clients to modify the query, by using query options such as $filter, $sort, and $page
    public async Task<IHttpActionResult> GetFoos(ODataQueryOptions<FooDTO> queryOptions)
    {
        using (var context = new FooBarContext())
        {
            return queryOptions.ApplyTo(context.Foos.AsQueryable().Select(f => new FooDTO
            {
                BarId = f.BarId,
                BarName = f.Bar.BarName,
                FooId = f.FooId,
                FooName = f.FooName
            }));
        }
    }
