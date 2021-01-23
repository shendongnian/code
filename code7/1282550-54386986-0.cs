    public bool IsList(object o)
    {
    	if (o == null) return false;
    
    	var type = o.GetType();
    	return o is IList && type.IsGenericType && type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
