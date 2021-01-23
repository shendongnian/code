    Action<int, int> a = (x, y) => Console.WriteLine(x + y);
	ParameterExpression p1 = Expression.Parameter(typeof(int), "p1");
	ParameterExpression p2 = Expression.Parameter(typeof(int), "p2");
	MethodCallExpression call;
	if (a.Method.IsStatic)
	{
		call = Expression.Call(a.Method, p1, p2);
	}
	else
	{
		var instance = Activator.CreateInstance(a.Method.DeclaringType);
		call = Expression.Call(Expression.Constant(instance), a.Method, p1, p2);
	}
