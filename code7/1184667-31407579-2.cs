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
    			var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames()
    				.Where(x => x.EndsWith(String.Format("{0}.resources", resource.Name)))
    				.Select(x => x.Replace(".resources", string.Empty)).ToList();
    			if (resources.Any())
    			{
    				return new ResourceManager(resources.First(), Assembly.GetExecutingAssembly()).GetString(name);
    			}
    		}
    
    		return name;
    	}
    }
