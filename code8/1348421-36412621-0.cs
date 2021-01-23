    public IEnumerable<T> Search( string searchString, Expression<Func<T, bool>> predicate )
    {
        var query = _dbSet.Where( x =>
            x.FirstName.StartsWith( searchString ) ||
            // ...
            x.Phone.EndsWith( searchString ) );
        if( null != predicate )
        {
            query = query.Where( predicate );
        }
            
        return query.ToList();
    }
