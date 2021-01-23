    public interface IReadOnlyIndexable<TKey, TValue>
    {
        TValue this[TKey key]{ get; }
    }
    
    public interface IIndexable<TKey, TValue> : IReadOnlyIndexable<TKey, TValue>
    {
        new TValue this[TKey key]{ get; set; }
    }
