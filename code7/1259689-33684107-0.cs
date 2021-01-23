    public Object GetFieldValue(this Object obj, String name)
    {
    	foreach (String part in name.Split('.'))
    	{
    		if (obj == null) { return null; }
    
    		Type type = obj.GetType();
    		FieldInfo info = type.GetField(part);
    		if (info == null) { return null; }
    
    		obj = info.GetValue(obj);
    	}
    	return obj;
    }
    
    // so we can use reflection to access the object properties
    public T GetFieldValue<T>(this Object obj, String name)
    {
    	Object retval = GetFieldValue(obj, name);
    	if (retval == null) { return default(T); }
    
    	// throws InvalidCastException if types are incompatible
    	return (T)retval;
    }
