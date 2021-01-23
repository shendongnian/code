	public IList GetListFromDictionary(IDictionary dict)
	{
	
			var type = dict.GetType();
			var newType = typeof(KeyValuePair<,>);
			var typeArgs = type.GetGenericArguments();
			var contructed  = newType.MakeGenericType(typeArgs);		
			var toListMethod = typeof(Enumerable).GetMethods().First(meth => meth.Name == "ToList");
			var method = toListMethod.MakeGenericMethod(new[] { contructed });
			return method.Invoke(null, new object[] { dict}) as IList;
	
	}
