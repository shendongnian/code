    public IEnumerable<TEntity> Srch(Expression<Func<TEntity, bool>> expression)
    {
        Func<TEntity, bool>> func = expression.Compile();
        IEnumerable<TEntity> srchList = _aQuery.ToList();
        return srchList.Where(o => func(o));
    }
