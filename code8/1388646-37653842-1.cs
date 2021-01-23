    public static bool IsGenericA(object instance)
	{
		Type t = instance.GetType();
		while(t.BaseType != null && t.BaseType != typeof(object))
		  t = t.BaseType;
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(a<>);
	}
	public static bool IsNonGenericA(object instance)
	{
		Type t = instance.GetType();
		while(t.BaseType != null && t.BaseType != typeof(object))
		  t = t.BaseType;
        return t == typeof(a);
	}
