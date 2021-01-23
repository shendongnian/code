    public static class DictEx
    {
        public static TVal GetValueOrDefault<TKey, TVal>(
            this IDictionary<TKey, TVal> dict, TKey key, TVal defaultValue = default(TVal))
        {
            TVal val;
            return dict.TryGetValue(key, out val) ? val : defaultValue;
        }
    }
