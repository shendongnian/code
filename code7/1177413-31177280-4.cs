  	public static MethodInfo Method<TR>(Expression<Func<TR>> expression)
	{
		return (expression.Body as MethodCallExpression).Method;
	}
	public static MethodInfo Method<T1, TR>(Expression<Func<T1, TR>> expression)
	{
		return (expression.Body as MethodCallExpression).Method;
	}
