	public static V SetValueIfExists<K, V>(this IDictionary<K, V> @this, K key, V value)
	{
		if (@this.ContainsKey(key))
		{
			@this[key] = value;
		}
	}
