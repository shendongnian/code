    MethodCallExpression orderByCallExpression = Expression.Call(
        typeof(Queryable),
        "OrderBy",
        new Type[] { queryableData.ElementType, queryableData.ElementType },
        whereCallExpression,
        Expression.Lambda<Func<string, string>>(pe, new ParameterExpression[] { pe }));
    
    // Create an executable query from the expression tree.
    IQueryable<string> results = queryableData.Provider.CreateQuery<string>(orderByCallExpression);
