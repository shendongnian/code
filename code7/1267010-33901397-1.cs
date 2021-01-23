    private IQueryable<TEntity> orderEntries(IQueryable<TEntity> entries)
    {
        if(defaultSortExpressions.Count == 0)
            return entries;        
        IOrderedQueryable<TEntity> ordered = Queryable.OrderBy(entries, (dynamic) defaultSortExpressions[0]);
        
        foreach (var sortExpression in defaultSortExpressions.Skip(1))
        {
            ordered = Queryable.ThenBy(ordered, (dynamic)sortExpression);            
        }
        return ordered;
    }
