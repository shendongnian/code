    public static JoinResult<TKey> JoinKeys<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
    {
        var left = new List<TKey>();
        var inner = new HashSet<TKey>();    // HashSet to optimize lookups
        var right = new List<TKey>();
        foreach (var l in first.Keys)   // O(n)
        {
            if (second.ContainsKey(l))
                inner.Add(l);
            else
                left.Add(l);
        }
        foreach (var r in second.Keys)      // O(m) (longhand for clarity)
        {
            if (!inner.Contains(r))
                right.Add(r);
        }
        return new JoinResult<TKey>
        {
            Left = left,
            Inner = inner,
            Right = right
        };
    }
    public class JoinResult<T>
    {
        public IEnumerable<T> Left { get; set; }
        public IEnumerable<T> Inner { get; set; }
        public IEnumerable<T> Right { get; set; }
    }
