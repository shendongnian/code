	protected T Get<T, TValue>(string propertyName, TValue value) where T : class
	{
		var par = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
		var eq = System.Linq.Expressions.Expression.Equal(System.Linq.Expressions.Expression.Property(par, propertyName), System.Linq.Expressions.Expression.Constant(value));
		var lambda = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(eq, par);
		return session.QueryOver<T>().Where(lambda).SingleOrDefault();
	}
