    string strJSON = string.Empty;
    if (state == System.Data.Entity.EntityState.Deleted)
    {
    	var databaseValues = this.Entry(auditedEntity).GetDatabaseValues();
    
    	// Get original values from the database (the only option, in the delete method they're lost)
    	DbEntityEntry dbEntityEntry = this.Entry(auditedEntity);
    	if (databaseValues != null)
    	{
    		dbEntityEntry.OriginalValues.SetValues(databaseValues);
    		var originalValues = this.Entry(auditedEntity).OriginalValues;
    		Type type = auditedEntity.GetType();
    		var auditDeletedEntity = Activator.CreateInstance(type);
    		// Get properties by reflection
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
    		strJSON = JsonConvert.SerializeObject(auditDeletedEntity, new EFNavigationPropertyConverter());
    	}
    }
    else
    {
    	strJSON = JsonConvert.SerializeObject(auditedEntity, new EFNavigationPropertyConverter());
    }
