    Program.<>c__DisplayClassb <>c__DisplayClassb = new Program.<>c__DisplayClassb();
	<>c__DisplayClassb.myList = new List<object>();
	<>c__DisplayClassb.myList.Add(buffer3);
	ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "p");
	Expression<Func<object, bool>> predicate = Expression.Lambda<Func<object, bool>>(Expression.Call(Expression.Field(Expression.Constant(<>c__DisplayClassb), fieldof(Program.<>c__DisplayClassb.myList)), methodof(List<object>.Contains(!0)), new Expression[]
	{
		parameterExpression
	}), new ParameterExpression[]
	{
		parameterExpression
	});
