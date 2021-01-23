    public static class KeyValuePairHelpers
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> 
            ToValueNonNullableKvps<TKey, TValue>(
                this IEnumerable<KeyValuePair<TKey, TValue?>> input,
                IEqualityComparer<TKey> equalityComparer = null)
                where TValue : struct
        {
            return (from kvp in input
                    where kvp.Value.HasValue
                    select kvp)
                      .ToDictionary(kvp => kvp.Key, 
                                    NonNullableValueProjection, 
                                    equalityComparer ?? EqualityComparer<TKey>.Default);
        }
        private static TValue NonNullableValueProjection<TKey, TValue>(
            KeyValuePair<TKey, TValue?> kvp)
            where TValue : struct
        {
            if (!kvp.Value.HasValue)
            {
                throw new InvalidOperationException("Cannot project null value");    
            }
            return (TValue)kvp.Value;
        }
    }
