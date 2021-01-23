    public static object BuildWhereClause(object model)
    {
        var properties = GetProperties(model);
		var result = (IDictionary<string, object>)new ExpandoObject();
		
		foreach (var property in properties)
        {
            var value = GetValue(property, model);
			result.Add(property.Name, value);
        }
        return result;
    }
