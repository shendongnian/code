    public IQueryable<TSource> PropertyEqualsValue<TSource>(IQueryable<TSource> query,
            string propertyName, object value)
    {
        var param = Expression.Parameter(typeof(TSource));
        var body = Expression.Equal(
            Expression.Property(param, propertyName),
            Expression.Constant(value)
        );
        var expr = Expression.Call(
            typeof(Queryable),
            "Where",
            new[] { typeof(TSource) },
            query.Expression,
            Expression.Lambda<Func<TSource, bool>>(body, param)
        );
        return query.Provider.CreateQuery<TSource>(expr);
    }
