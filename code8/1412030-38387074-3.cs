    public IQueryable PropertyEqualsValue(IQueryable query,
            Type type, string propertyName, object value)
    {
        var param = Expression.Parameter(type);
        var body = Expression.Equal(
            Expression.Property(param, propertyName),
            Expression.Constant(value)
        );
        var expr = Expression.Call(
            typeof(Queryable),
            "Where",
            new[] { type },
            query.Expression,
            Expression.Lambda(body, param)
        );
        return query.Provider.CreateQuery(expr);
    }
