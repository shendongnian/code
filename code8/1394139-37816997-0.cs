    public interface IVariantReadOnlyDictionary<in TKey, out TValue>
	{
        bool ContainsKey(TKey key);
        //bool TryGetValue(TKey key, out TValue value);  // cannot be contravariant in TValue
		TValue this[TKey key] { get; }
        //IEnumerable<TKey> Keys { get; }  // cannot be covariant in TKey
		IEnumerable<TValue> Values { get; }
        int Count { get; }  
		
		//cannot extend IEnumerable<KeyValuePair<TKey, TValue>>
	}
