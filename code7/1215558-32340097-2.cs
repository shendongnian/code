    public virtual IEnumerable<TEntity> GetSorted<TSortedBy>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,...)
    {
        IQueryable<TEntity> query = dbSet;
        //...
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        //...
    }
