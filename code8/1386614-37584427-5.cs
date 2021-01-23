    public IEnumerable<TEntity> Srch(Expression<Func<TEntity, bool>> expression)
    {
        Func<TEntity, bool>> func = expression.Compile();
        IEnumerable<TEntity> srchList = _aQuery.Where(o => func(o));
        return srchList;
    }
