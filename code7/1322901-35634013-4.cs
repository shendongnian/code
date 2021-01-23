    static class ExpressionUtils
    {
    	public static IEnumerable<Expression<Func<TEntity, object>>> Includes<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> accessor)
    	{
    		var root = accessor.Parameters[0];
    		for (var node = accessor.Body as MemberExpression; node != null && node.Expression != root; node = node.Expression as MemberExpression)
    			yield return Expression.Lambda<Func<TEntity, object>>(node.Expression, root);
    	}
    }
