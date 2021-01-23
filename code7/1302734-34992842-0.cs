    private static List<KeyValue> ReadCollection<T>(IList<T> collection,
        string keyName, string valueName)
	{		
		List<KeyValue> list = new List<KeyValue>();
		Func<T, int> keyFunction = GenerateLambda<T, int>(keyName);
		Func<T, string> valueFunction = GenerateLambda<T, string>(valueName);
		for (int i = 0; i < collection.Count; i++)
		{
			T elem = collection[i];
			// I can't use this notation, but only elem.Id
			int key = keyFunction(elem);
			// I can't use this notation, but only elem.Name
			string value = valueFunction(elem);
			list.Add(new KeyValue(key, value));
		}
		return list;
	}
	
	private static Func<T, TProp> GenerateLambda<T, TProp>(string propertyName)
	{
		var p = Expression.Parameter(typeof(T));
		var expr = Expression.Lambda<Func<T, TProp>>(Expression.PropertyOrField(p, propertyName), p);
		return expr.Compile();
	}
