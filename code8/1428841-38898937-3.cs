    public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
	{
		if (propertyLambda == null) throw new ArgumentNullException("propertyLambda");
		var me = propertyLambda.Body as MemberExpression;
		if (me == null)
		{
			throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
		}
		return me.Member.Name;
	}
