    public static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), string.Empty); // I don't care about some naming
        Expression body = param;
        foreach (var member in propertyName.Split('.'))
        {
            body = Expression.PropertyOrField(body, member);
        }
        LambdaExpression sort = Expression.Lambda(body, param);
        MethodCallExpression call = Expression.Call(
            typeof(Queryable),
            (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
            new[] { typeof(T), body.Type },
            source.Expression,
            Expression.Quote(sort));
        return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
    }
