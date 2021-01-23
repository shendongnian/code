    Type sourceType = typeof(Source);
	ParameterExpression source = Expression.Parameter(sourceType);
	var createModel = Expression.New(typeof(Dest));
	var bindings = new List<MemberAssignment>();
	foreach (var prop in sourceType.GetProperties())
	{
		var v1 = Expression.Call(source, prop.GetGetMethod());
		var destinationProperty = typeof(Dest).GetProperty(prop.Name);
		
		bindings.Add(Expression.Bind(destinationProperty, v1));
	}
	var init = Expression.MemberInit(createModel, bindings);
	var lambdaExpression = Expression.Lambda<Func<Source, Dest>>(init, source);
