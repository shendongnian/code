    public interface IReadOnlyIndexable<TKey, TValue> : IEnumerable<TKey, TValue>
    {
        TValue this[TKey key]{ get; }
        int Count { get; }
    }
    
    public interface IIndexable<TKey, TValue> : IReadOnlyIndexable<TKey, TValue>
    {
        new TValue this[TKey key]{ get; set; }
    }
