    public static class Extended
    {
        public static void AddKeyIfNotExists<T, V>(this IDictionary<T,V> dictionary, T key, V Value)
        {
            if (!dictionary.ContainsKey(key))
	        {
                dictionary.Add(key, Value);
	        }             
        }
    }
