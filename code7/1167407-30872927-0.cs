    DbSet<TEntity> set = dbSet;
    foreach (var includeProperty in includeProperties.Split
        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    {
        set = set.Include(includeProperty);
    }
    IQueryable<TEntity> query = set;
    if (filter != null)
    {
        query = query.Where(filter);
    }
