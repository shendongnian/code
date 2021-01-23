	public static void ThrowIfNull<T>(Expression<Func<T>> expr)
	{
		var member = expr.Body as MemberExpression;
		var name = member.Member.Name;
		var value = expr.Compile()();
		if (value == null)
		{
			throw new ArgumentNullException(name);
		}
	}
