	public static double AgreggateDynamic<T>(this IEnumerable<T> list, string propertyName, string func)
	{
		var source = Expression.Parameter(typeof(IEnumerable<T>), "source");
		var item = Expression.Parameter(typeof(T), "item");
		Expression value = Expression.PropertyOrField(item, propertyName);
		if (value.Type != typeof(double)) value = Expression.Convert(value, typeof(double));
		var selector = Expression.Lambda<Func<T, double>>(value, item);
		var methodCall = Expression.Lambda<Func<IEnumerable<T>, double>>(
			Expression.Call(typeof(Enumerable), func, new Type[] { item.Type }, source, selector),
			source);
		var method = methodCall.Compile();
		return method(list);
	}
