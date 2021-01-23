    var types = Assembly.GetExecutingAssembly().GetTypes()
    	.Where(t => t.IsClass && !t.IsAbstract)
    	.Select(t => new { Type = t, GenericBase = FindGenericBaseTypeOf(t, typeof(MyClass<>)) })
    	.Where(ts => ts.GenericBase != null)
    	.Select(ts => ts.GenericBase.GetGenericArguments().First())
    	.ToArray();
