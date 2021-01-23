    public static bool SearchProperties(object target, string searchString)
    {
    	if (target == null) return false;
    	// Common types
    	var convertible = target as IConvertible;
    	if (convertible != null)
    	{
    		var typeCode = convertible.GetTypeCode();
    		if (typeCode == TypeCode.String) return target.ToString() == searchString;
    		if (typeCode == TypeCode.DBNull) return false;
    		if (typeCode != TypeCode.Object)
    		{
    			try
    			{
    				var value = Convert.ChangeType(searchString, typeCode);
    				return target.Equals(value);
    			}
    			catch { return false; }
    		}
    	}
    	if (target is DateTimeOffset)
    	{
    		DateTimeOffset value;
    		return DateTimeOffset.TryParse(searchString, out value) && value == (DateTimeOffset)target;
    	}
    	var enumerable = target as IEnumerable;
    	if (enumerable != null)
    	{
    		// Collection
    		foreach (var item in enumerable)
    			if (SearchProperties(item, searchString)) return true;
    	}
    	else
    	{
    		// Complex type
    		var properties = target.GetType().GetProperties();
    		foreach (var property in properties)
    		{
    			if (property.GetMethod == null || property.GetMethod.GetParameters().Length > 0) continue;
    			var value = property.GetValue(target);
    			if (SearchProperties(value, searchString)) return true;
    		}
    	}
    	return false;
    }
