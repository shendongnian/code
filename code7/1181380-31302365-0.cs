    public Func<T> BuildGenericStaticFunc<T>()
    {
    	var type = typeof(T);
    	return Expression.Lambda<Func<T>>(
    		Expression
    			.Call(
    				type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public)
                        .MakeGenericMethod(type),
    				Expression.Constant(type)
    				))
    			.Compile();
    }
    var result = BuildGenericStaticFunc<MyClass>();
