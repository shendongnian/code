	public Dictionary<string, string> MapToDictionary(object source, string name)
	{
		var dictionary = new Dictionary<string, string>();
		MapToDictionaryInternal(dictionary, source, name);
		return dictionary;
	}
	private void MapToDictionaryInternal(
        Dictionary<string, string> dictionary, object source, string name)
	{
		var properties = source.GetType().GetProperties();
		foreach(var p in properties) 
		{
		    var key = name + "." + p.Name;
			object value = p.GetValue(source, null);
			Type valueType = value.GetType();
			
			if (valueType.IsPrimitive || valueType == typeof (String))
			{
				dictionary[key] = value.ToString();
			}
			else if (value is IEnumerable)
			{
				var i = 0;
				foreach (object o in (IEnumerable) value)
				{
					MapToDictionaryInternal(dictionary, o, key + "[" + i + "]");
                    i++;
				}
			}
			else
			{
				MapToDictionaryInternal(dictionary, value, key);
			}
		}
	}
		
