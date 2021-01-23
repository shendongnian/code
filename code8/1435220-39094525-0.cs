    public static class DictionaryExtensions
    {
        public static T1 ValueOrDefault<T, T1>(this IDictionary<T, T1> dictionary, T key)
        {
            if (key == null || dictionary == null)
                return default(T1);
            T1 value;
            return dictionary.TryGetValue(key, out value) ? value : default(T1);
        }
    }
