	public static bool IfContainsKeyThenExecute<K, V>(
		this Dictionary<K, V> dictionary, K key, Action<K, V> action)
	{
		V value;
		var found = dictionary.TryGetValue(key, out value);
		if (found)
		{
			action(key, value);
		}
		return found;
	}
