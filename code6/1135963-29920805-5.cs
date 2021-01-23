    class CustomDictionary<TKey,TValue> : IDictionary<TKey,TValue>
    {
        private Dictionary<TKey,TValue> _dictionary;
		// Implement the interface IDictionary here
		// send the logic to your private Dictionary
		public void Add(KeyValuePair<TKey, TValue> item)
		{
             // create your logic
		    _dictionary.Add(item.Key, item.Value);
		}
    }
