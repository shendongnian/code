	public static string FancyTypeName(Type type)
	{
		var typeName = type.Name.Split('`')[0];
		if (type.IsGenericType)
		{
			typeName += string.Format("<{0}>", string.Join(",",
                 type.GetGenericArguments().Select(v => FancyTypeName(v)).ToArray())
               );
		}
		return typeName;
	}
