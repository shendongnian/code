    public interface ILookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
    {
        // Summary:
        //     Gets the System.Collections.Generic.IEnumerable<T> sequence of values indexed
        //     by a specified key.
        //
        // Parameters:
        //   key:
        //     The key of the desired sequence of values.
        //
        // Returns:
        //     The System.Collections.Generic.IEnumerable<T> sequence of values indexed
        //     by the specified key.
        IEnumerable<TElement> this[TKey key] { get; }
    }
