    using (var ctx = new TestContext())
    {
    	Entity ent = entity.Single(x => x.Id == id);
    	entity.FirstName = "New name";
    
    	var entry = ((IObjectContextAdapter)ctx).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
    	var currentValues = entry.CurrentValues;
    	var originalValues = entry.OriginalValues;
    
    	AuditEntityModified(originalValues, currentValues);
    }
    
    public static void AuditEntityModified(DbDataRecord orginalRecord, DbUpdatableDataRecord currentRecord, string prefix = "")
    {
    	for (var i = 0; i < orginalRecord.FieldCount; i++)
    	{
    		var name = orginalRecord.GetName(i);
    		var originalValue = orginalRecord.GetValue(i);
    		var currentValue = currentRecord.GetValue(i);
    
    		var valueRecord = originalValue as DbDataRecord;
    		if (valueRecord != null)
    		{
    			// Complex Type
    			AuditEntityModified(valueRecord, currentValue as DbUpdatableDataRecord, string.Concat(prefix, name, "."));
    		}
    		else
    		{
    			if (!Equals(currentValue, originalValue))
    			{
    				// Add modified values
    			}
    		}
    	}
    }
