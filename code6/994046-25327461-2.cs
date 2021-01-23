    var propertyMethods = genericMethod.GetType()
    	.GetMethods()
    	.Where(m => m.Name == "Property" && m.IsGenericMethodDefinition)
    	.ToList();
    
    if (Nullable.GetUnderlyingType(typeof(Boolean?)) != null)
    {
    	propertyMethod = propertyMethods.ElementAt(1)
    		.MakeGenericMethod(new[] { Nullable.GetUnderlyingType(typeof(Boolean?)) });
    
    }
    else
    {
    	propertyMethod = propertyMethods.ElementAt(0)
    		.MakeGenericMethod(new[] { typeof(Boolean) });
    }
