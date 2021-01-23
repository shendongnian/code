    public static IQueryable<TEntity> SomeMethod<TEntity>(
        this IQueryable<TEntity> source,
        ...,
        Expression<Func<TEntity, object>> orderByExpression = null)
    {
        var result = source;
        result = preprocess(result);
        result = result.ApplyOrderBy(orderByExpression);
        result = postprocess(result);
        return result;    
    }
