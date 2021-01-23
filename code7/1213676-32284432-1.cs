    public static class TypeExtensions
    {
    	public static PropertyInfo GetPropertyByPath(this Type someType, string objectPath)
    	{
    		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
    		string[] objectPathParts = objectPath.Split('.');
    		
    		// #1 property in the object path should be obtained from T
    		PropertyInfo currentProperty = someType.GetProperty(objectPathParts[0], bindingFlags);
    		for (int propertyIndex = 1; propertyIndex < objectPathParts.Length; propertyIndex++)
    		{
    			// While all other association properties should be obtained
    			// accessing PropertyInfo.PropertyType
    			currentProperty = currentProperty.PropertyType.GetProperty(objectPathParts[propertyIndex], bindingFlags);
    			if (currentProperty == null)
    				throw new ArgumentException("Some property in the object path doesn't exist", "objectPath");
    		}
    		
    		return currentProperty;
    	}
    }
