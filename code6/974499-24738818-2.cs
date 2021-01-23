    public override IQueryable<T> GetEverything(Expression<Func<T, bool>> predicate = null)
    {
        var query = Get().Where(i => i.Active == true);
        if(predicate != null)
            query = query.Where(predicate);
        return query.Select(i => new T(i));
    }
