     public static TResult GetValue<TKey, TValue, TResult>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (!dictionary.ContainsKey(key))
            {
                return default(TResult);
            }
    
            return (TResult)dictionary[key];
        }
