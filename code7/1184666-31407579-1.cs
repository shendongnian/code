    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `Enum`.
    /// </summary>
    public static string GetDisplayName(this Enum enumValue)
    {
    	var displayAttrib = enumValue.GetType()
    		.GetMember(enumValue.ToString())
    		.First()
    		.GetCustomAttribute<DisplayAttribute>();
    
    	var name = displayAttrib.Name;
    	if (String.IsNullOrEmpty(name))
    	{
    		return enumValue.ToString();
    	}
    	else
    	{
    		var resource = displayAttrib.ResourceType;
    		if (resource != null)
    		{
    			var resourceManager = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(resource);
    			var property = resource.GetProperty(name);
    			name = property.GetMethod.Invoke(resourceManager, null).ToString();
    		}
    
    		return name;
    	}
    }
