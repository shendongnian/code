	public static class DictionaryExtensions
	{
		public static T Get<T>(this Dictionary<string, object> dictionary, string key)
		{
			object value = null;
			return dictionary.TryGetValue(key, out value) ? (T)value : default(T);
		}
	}
	
