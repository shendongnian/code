    private static readonly MethodInfo ToStringMethod = typeof(object).GetMethod("ToString");
    private static readonly MethodInfo StringContainsMethod = typeof(string).GetMethod("Contains");
    public static Expression<Func<T, bool>> BuildFilterPredicate<T>(string q)
    {
        var query = Expression.Constant(q);
        var type = typeof(T);
        var lambdaParam = Expression.Parameter(type);
        var predicates = type.GetProperties().SelectMany(p => PredicateContainsBuilder(lambdaParam, p, query)).ToList();
        Expression body = predicates[0];
        body = predicates.Skip(1).Aggregate(body, Expression.OrElse);
        return Expression.Lambda<Func<T, bool>>(body, lambdaParam);
    }
    private static IEnumerable<MethodCallExpression> PredicateContainsBuilder(Expression lambdaParam, PropertyInfo prop, Expression query)
    {
        if (prop.PropertyType.IsClass)
            return new List<MethodCallExpression> { Expression.Call(Expression.Call(Expression.Property(lambdaParam, prop), ToStringMethod), StringContainsMethod, query) };
        var properties = prop.PropertyType.GetProperties();
        return properties.Select(p => Expression.Call(Expression.Call(Expression.Property(lambdaParam, p), ToStringMethod), StringContainsMethod, query)).ToList();
    }
