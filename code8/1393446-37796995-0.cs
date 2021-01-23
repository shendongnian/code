    public static class ExtensionMethods
    {
        public static async Task<Dictionary<TKey, TValue>> ToDictionaryAsync<TInput, TKey, TValue>(
            this IEnumerable<TInput> enumerable,
            Func<TInput, TKey> syncKeySelector,
            Func<TInput, Task<TValue>> asyncValueSelector)
        {
            Dictionary<TKey,TValue> dictionary = new Dictionary<TKey, TValue>();
            foreach (var item in enumerable)
            {
                var key = syncKeySelector(item);
                var value = await asyncValueSelector(item);
                dictionary.Add(key,value);
            }
            return dictionary;
        }
    }
