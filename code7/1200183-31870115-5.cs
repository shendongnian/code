	public static V SetValueIfNotExists<K, V>(this IDictionary<K, V> @this, K key, V value)
	{
		if (!@this.ContainsKey(key))
		{
			@this[key] = value;
		}
	}
