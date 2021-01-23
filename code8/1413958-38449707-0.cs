    foreach (var propertyInfo in type.GetProperties())
    {
    	if (!propertyInfo.PropertyType.IsArray && !propertyInfo.PropertyType.IsGenericType)
    	{
    		var propertyValue = originalValues.GetValue<object>(propertyInfo.Name);
    		auditDeletedEntity.GetType().InvokeMember(propertyInfo.Name,
    			BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
    			Type.DefaultBinder, auditDeletedEntity, new[] { propertyValue });
    	}
    }
