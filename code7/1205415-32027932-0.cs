	static void Foo(List<Dictionary<string, string>> ProductItemsDictionary, string key)
	{
		string value;
		foreach (var dictionary in ProductItemsDictionary)
			if (dictionary.TryGetValue(key, out value)) { /* Use value */ }
		// Not found
	}
 
