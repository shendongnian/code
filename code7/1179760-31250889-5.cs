    public class ReadOnlyDict<K, V>
	{
		private Dictionary<K, V> dictionary;
		public ReadOnlyDict(Dictionary<K, V> dict)
		{
			dictionary = dict;
		}
		public V this[K key]
		{
			get
			{
				return dictionary[key];
			}
		}
		// Add more methods per your request
	}
