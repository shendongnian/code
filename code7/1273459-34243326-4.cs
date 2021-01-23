    public static IQueryable Select(this IQueryable source, string selector, params object[] values)
    {
    	if (source == null) throw new ArgumentNullException("source");
    	if (selector == null) throw new ArgumentNullException("selector");
    	LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
    	return source.Provider.CreateQuery(
    		Expression.Call(
    			typeof(Queryable), "Select",
    			new Type[] { source.ElementType, lambda.Body.Type },
    			source.Expression, Expression.Quote(lambda)));
    }
