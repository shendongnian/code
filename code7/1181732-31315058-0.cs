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
			object value = p.GetValue(source, null);
			Type valueType = value.GetType();
			if (valueType.IsPrimitive || valueType == typeof (String))
			{
				dictionary[name + "." + p.Name] = value.ToString();
			}
			else if (value is IEnumerable)
			{
				var i = 0;
				foreach (object o in (IEnumerable) value)
				{
					MapToDictionaryInternal(dictionary, o, 
                        name + "." + p.Name + "[" + i + "]");
                    i++;
				}
			}
			else
			{
				MapToDictionaryInternal(dictionary, value, name + "." + p.Name);
			}
		}
	}
		
