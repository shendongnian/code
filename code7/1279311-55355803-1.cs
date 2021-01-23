    [EnableQuery()] // Enables clients to modify the query, by using query options such as $filter, $sort, and $page
    public IQueryable<Product> GetFoos()
    {
        using (var context = new FooBarContext())
        {
            return context.Foos;
        }
    }
