    namespace System.Collections.Generic
    {
        public static class DictionaryExt
    	{
    		public static ReadOnlyDict<K, V> ToReadOnlyDictionary<K, V>(this Dictionary<K, V> dict)
    		{
    			return new ReadOnlyDict<K, V>(dict);
    		}
    	}
    }
