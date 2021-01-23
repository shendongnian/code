    Children = y.SelectMany(item =>
    {
    	IEnumerable<dynamic> itemProps = item.GetType().GetProperties();
    	List<dynamic> properties = itemProps.Where(p => !Enumerable.Contains(keyProperties,p.Name)).ToList();
    	var result = new ExpandoObject();
    	foreach(var property in properties)
    	{
    		var value = property.GetValue(item, null);
    		if(value != null)
    			((IDictionary<string, object>)result).Add(property.Name, value);
    	}
    	return (IDictionary<string, object>)result;
    }).GroupBy(prop => prop.Key, prop => prop.Value)
    .Select(g => 
    {
    	var result = new ExpandoObject();
    	((IDictionary<string, object>)result).Add(g.Key, g.ToArray());
    	return result;
    })
    .ToList()
