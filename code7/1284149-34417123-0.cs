    public static class DictionaryExtensions
    {
        public static void ForEach<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            Action<TKey, TValue> action) {
            foreach (KeyValuePair<TKey, TValue> pair in dictionary) {
                action(pair.Key, pair.Value);
            }
        }
    }
