    public static class DictionaryExtensions
    {
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            foreach (var pair in dictionary)
            {
                action(pair.Key, pair.Value);
            }
        }
    }
    // ...
    
    d.ForEach((s, s1) =>
    {
        Console.WriteLine($"{s} ({s1})");
    });
