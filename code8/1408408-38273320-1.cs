    private static List<string> GetNullOrEmptyPropertiesList(object myObject)
    {
    	var list = new List<string>();
    	AddNullOrEmptyProperties(myObject, list);
    	return list;
    }
    
    private static void AddNullOrEmptyProperties(object myObject, List<string> list, string path = null)
    {
    	if (myObject == null) return;
    	var type = myObject.GetType();
    	if (type.IsPrimitive || type == typeof(string)) return;
    	foreach (var pi in myObject.GetType().GetProperties())
    	{
    		if (!pi.CanRead || pi.GetIndexParameters().Length > 0) continue;
    		var name = path != null ? path + "." + pi.Name : pi.Name;
    		var value = pi.GetValue(myObject);
    		if (pi.IsDefined(typeof(RequiredAttribute)) && (value == null || (value as string) == string.Empty))
    			list.Add(name);
    		AddNullOrEmptyProperties(value, list, name);
    	}
    }
