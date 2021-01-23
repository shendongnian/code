    public static IDictionary<string, object> Convert<TKey, TValue>(IDictionary<TKey, TValue> genDictionary)
	{
		return genDictionary.Select(kvp => new KeyValuePair<string, object>(kvp.Key.ToString(), (object)kvp.Value)).ToDictionary(x => x.Key, x => x.Value);
	}
		
		
