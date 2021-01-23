    class CustomDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
		public new void Add(TKey key, TValue value)
		{
			// create your logic
			base.Add(key, value);
		}
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.Add(item.Key, item.Value);
		}
	}
