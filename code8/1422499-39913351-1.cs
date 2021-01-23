	public static int GetGenericParameterCount(Type type)
	{
		if (!type.IsGenericType)
		{
			return 0;
		}
		var genericTypeDefName = type.GetGenericTypeDefinition().Name;
		int tickIndex = genericTypeDefName.LastIndexOf('`');
		if (tickIndex == -1)
		{
			// This will happen for nested types like "OuterClass<int>.InnerClass".
			return 0;
		}
		return int.Parse(genericTypeDefName.Substring(tickIndex + 1), NumberStyles.None);
	}
