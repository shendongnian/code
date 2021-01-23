    public static class DictionaryExtensions
    {
        public static string ToJson<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary);
        }
    }
