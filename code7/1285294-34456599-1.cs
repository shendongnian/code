    public IQueryable<T> GetQueryable()
    {
        var results = _repository.Table;
        if (typeof(IStoreScopedEntity).IsAssignableFrom(typeof(T)))
        {
            results = results.Where((Expression<Func<T, bool>>)
                typeof(StoreScopedEntity)
                .GetMethod("IdPredicate", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(typeof(T))
                .Invoke(null, new object[] { EngineContext.Current.StoreScopeId }));
        }
        return results;
    }
