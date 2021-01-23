	public static void ThrowIfNull<T>(params Expression<Func<T>>[] exprs)
	{
		foreach(var expr in exprs)
		{
			var member = expr.Body as MemberExpression;
			var name = member.Member.Name;
			var value = expr.Compile()();
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}
		}
	}
