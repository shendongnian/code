    internal static IQueryable<T> ApplyOrderBy<T>(
        this IQueryable<T> source,
        Expression<Func<T, object>> orderByExpression = null)
    {
    	if (orderByExpression == null) return source;
    	var body = orderByExpression.Body;
    	// Strip the Convert if any
    	if (body.NodeType == ExpressionType.Convert)
    		body = ((UnaryExpression)body).Operand;
    	// Create new selector
    	var keySelector = Expression.Lambda(body, orderByExpression.Parameters[0]);
    	// Here we cannot use the typed Queryable.OrderBy method because
    	// we don't know the TKey, so we compose a method call instead
    	var queryExpression = Expression.Call(
    		typeof(Queryable), "OrderBy", new[] { typeof(T), body.Type },
    		source.Expression, Expression.Quote(keySelector));
    	return source.Provider.CreateQuery<T>(queryExpression);
    }
