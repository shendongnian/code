    public IQueryable<TEntity> OrderingEntitiesFrom(IQueryable<TEntity> query)
    {
        var parameter = _keySelector.Parameters.Single();
        var address = _keySelector.Body;
        var citySelector = Expression.Lambda<Func<TEntity, string>>(Expression.Property(address, "City"), parameter);
        var streetSelector = Expression.Lambda<Func<TEntity, string>>(Expression.Property(address, "Street"), parameter);
        return query.OrderBy(citySelector).ThenBy(streetSelector);
    }
