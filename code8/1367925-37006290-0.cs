	public static IDictionary<string, T> ToDictionary<T>(this object source)
	{
		if (source == null)
			ThrowExceptionWhenSourceArgumentIsNull();
		
		var dictionary = new Dictionary<string, T>();
		AddPropertiesToDictionary(new List<string>(), source, dictionary);
		return dictionary;
	}
	
	private static void AddPropertiesToDictionary<T>(IList<string> path, object source, IDictionary<string, T> dictionary)
	{
		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
		{
			var value = property.GetValue(source);
			if (IsOfType<T>(value))
			{
				if (property.PropertyType.IsSerializable) {
					dictionary.Add((path.Any() ? string.Join(".", path) + "." : "") + property.Name, (T)value);
				}
				else
				{
					path.Add(property.Name);
					AddPropertiesToDictionary(path, value, dictionary);
				}
			}
		}
	}
