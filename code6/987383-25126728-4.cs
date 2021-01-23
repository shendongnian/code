    public sealed class Listionary<K, T> : IDictionary<K, T>, IList<T>
    {
        private struct ListionaryPair
        {
            public ListionaryPair(T item) : this()
            {
                Item = item;
            }
            public ListionaryPair(K key, T item) : this()
            {
                Key = key;
                Item = item;
            }
            public K Key { get; private set; }
            public T Item { get; private set; }
            public bool HasKey { get; private set; }
        }
        private readonly List<ListionaryPair> list = new List<ListionaryPair>();
