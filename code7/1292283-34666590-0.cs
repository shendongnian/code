    public IQueryable<TEntity> OrderingEntitiesFrom(IQueryable<TEntity> query)
    {
        var parameter = Expression.Parameter(typeof (TEntity));
        var address = Expression.Invoke(_keySelector, parameter);
        var citySelector = Expression.Lambda<Func<TEntity, string>>(Expression.Property(address, "City"), parameter);
        var streetSelector = Expression.Lambda<Func<TEntity, string>>(Expression.Property(address, "Street"), parameter);
        return query.OrderBy(citySelector).ThenBy(streetSelector);
    }
