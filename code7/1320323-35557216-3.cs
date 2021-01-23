    public static class DictionaryExtensions
    {
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dict, Action<KeyValuePair<TKey, TValue>> action)
        {
            foreach (var item in dict)
                action(item);
        }
    }
