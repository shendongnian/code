	public static Expression<Func<T, Double[]>> BuildExpression<T>()
	{
		ParameterExpression param = Expression.Parameter(typeof(T));
		Expression[] array = typeof(T).GetProperties()
			.Where(p => p.Name.StartsWith("input") || p.Name.StartsWith("output"))
			.OrderBy(p => p.Name)
			.Select(p => (Expression)Expression.Property(Expression.Property(param, p), "Value"))
			.ToArray();
		Expression body = Expression.NewArrayInit(typeof(Double), array);
		return Expression.Lambda<Func<T, Double[]>>(body, param);
	}
