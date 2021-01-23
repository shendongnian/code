	static ConcurrentDictionary<string, Lazy<Action<object, object>>> CachedProperties = 
		new ConcurrentDictionary<string, Lazy<Action<object, object>>>();
	
	static void SetProperty(object obj, string name, object value)
	{
		if(obj==null)
			throw new ArgumentNullException("obj");
		Type objType = obj.GetType();
		string key =  objType.FullName + ":" + name;
		Action<object, object> f = 
		CachedProperties.GetOrAdd(key, k => 
			new Lazy<Action<object,object>>(() => {
				PropertyInfo prop = objType.GetProperty(name);
				if(prop==null){
					return (s,v) => {};
				}
				ParameterExpression pobj = 
					Expression.Parameter(typeof(object));
				ParameterExpression pval = 
					Expression.Parameter(typeof(object));
				Expression left = Expression.Property(
					Expression.TypeAs( pobj, objType), prop);
				Expression right = Expression.Convert(pval, prop.PropertyType);
	
				return Expression
				.Lambda<Action<object, object>>(
					Expression.Assign(left,right), pobj, pval).Compile();
			})).Value;
	
		f(obj,value);
	}
