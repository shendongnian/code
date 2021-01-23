	public static Expression<Func<TElementType, object>> Field<TElementType, TReturnType>(this Expression<Func<TElementType, TReturnType>> expr, string field)
	{
		Type entityType = typeof(TElementType);
		PropertyInfo propertyInfo = entityType.GetProperty(field);
		if (propertyInfo == null)
			throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
		ParameterExpression parameterExpression = Expression.Parameter(entityType, "e");
		
		return Expression.Lambda<Func<TElementType, object>>(
			Expression.Property(parameterExpression, propertyInfo),
			parameterExpression
		);
	}
