    public static Expression<Func<T, TMap>> MapNavProperty<T, TMap, U, UMap>(this Expression<Func<T, TMap>> parent, Expression<Func<U, UMap>> nav, string propName)
    {
    	var parameter = parent.Parameters[0];
    	var body = parent.Body.ReplaceMemberAssignment(
    		typeof(TMap).GetProperty(propName),
    		nav.ReplaceParameter(Expression.Property(parameter, propName))
    	);
    	return Expression.Lambda<Func<T, TMap>>(body, parameter);
    }
