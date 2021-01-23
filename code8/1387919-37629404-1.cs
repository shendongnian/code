    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class DictionaryExtensions {
        public static HashSet<KeyValuePair<TKey, TValue>> ToSet<TKey, TValue>(this Dictionary<TKey, TValue> dict) {
            return new HashSet<KeyValuePair<TKey, TValue>>(dict.ToList());
        }
    } 
