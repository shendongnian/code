    static class ExpressionUtils
    {
    	public static Expression<Func<TEntity, object>> SubEntity<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> accessor)
    	{
    		var parent = ((MemberExpression)accessor.Body).Expression;
    		if (parent == accessor.Parameters[0]) return null;
    		return Expression.Lambda<Func<TEntity, object>>(parent, accessor.Parameters);
    	}
    }
