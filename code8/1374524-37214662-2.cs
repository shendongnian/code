    if (change.Property(prop.Name).IsModified)
    {
    	var changeLoged = new ChangeLog
    	{
    		PropertyName = prop.Name,
    		EntityName = entityName,
    		PrimaryKeyValue = primaryKeyValue,
    		DateChange = now,
    		OldValue = originalValue.ToString(),
    		NewValue = currentValue.ToString(),
    		ChangedBy = "test"
    	};
    	ChangeLog.Add(changeLoged);
    }
