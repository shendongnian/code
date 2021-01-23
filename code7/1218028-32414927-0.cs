    public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navProps)
    {
        T item = null;
        using (var context = new MyDbContext())
        {
            IQueryable<T> query = context.Set<T>();
            //Include the navigations properties as part of the query
            if (navProps!= null)
            {
                query = navProps.Aggregate(query, (current, include) => current.Include(include));
            }
            item = query.Where(where).FirstOrDefault();
        }
        return item;
    }
