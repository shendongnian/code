    public static IEnumerable<Type> BaseTypesOf(Type t)
    {
    	while (t != null)
    	{
    		yield return t;
    		t = t.BaseType;
    	}
    }
    
    public static Type FindGenericBaseTypeOf(Type t, Type openType)
    {
    	return BaseTypesOf(t)
    		.FirstOrDefault(bt => bt.IsGenericType && bt.GetGenericTypeDefinition() == openType);
    }
