    public IQueryable<TEntity> OrderingEntitiesFrom(IQueryable<TEntity> query)
    {
        var parameter = Expression.Parameter(typeof (TEntity));
        var addressSelector = Expression.Invoke(_keySelector, parameter);
        var citySelector = (Expression<Func<Address, string>>)(x => x.City);
        var invokeCitySelector = Expression.Lambda<Func<TEntity, string>>(Expression.Invoke(citySelector, addressSelector), parameter);
        var streetSelector = (Expression<Func<Address, string>>)(x => x.Street);
        var invokeStreetSelector = Expression.Lambda<Func<TEntity, string>>(Expression.Invoke(streetSelector, addressSelector), parameter);
        return query.OrderBy(invokeCitySelector).ThenBy(invokeStreetSelector);
    }
