	public static Expression<Func<TElementType, string>> Field<TElementType, TReturnType>(this Expression<Func<TElementType, TReturnType>> expr, string field)
	{
		Type entityType = typeof(TElementType);
		PropertyInfo propertyInfo = entityType.GetProperty(field);
		if (propertyInfo == null)
			throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
		ParameterExpression parameterExpression = Expression.Parameter(entityType, "e");
		
		return Expression.Lambda<Func<TElementType, string>>(
			Expression.Property(parameterExpression, propertyInfo),
			parameterExpression
		);
	}
