    private static void SetUpdatableElements(BsonDocument bdoc, BsonDocument updateDefintion, HashSet<string>() excluded = null, string parentName = "")
    {
    	var excluded = excluded ?? new HashSet<string>()
    	parentName = !string.IsNullOrWhiteSpace(parentName) ? $"{parentName}." : "";
    	foreach (var item in bdoc)
    	{
    		if (item.Value.IsObjectId || // skip _id                     
    			item.Value.IsBsonNull || // skip properties with null values
    			excluded.Contains(item.Name)) // skip other properties that should not be updated
    		{
    			continue;
    		}
    		if (!item.Value.IsBsonDocument) // to avoid override nested objects)
    		{
    			updateDefintion = updateDefintion.Add($"{parentName}{item.Name}", item.Value);
    			continue;
    		}
            // recursively set nested elements to avoid overriding the full object
    		SetUpdatableElements(item.Value.ToBsonDocument(), updateDefintion, item.Name);
    	}
    }
