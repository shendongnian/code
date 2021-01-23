    public sealed class ReadOnlyCollectionFromEnumerable<T>: IReadOnlyCollection<T>
    {
        readonly IEnumerable<T> _data;
        public ReadOnlyCollectionFromEnumerable(IEnumerable<T> data, int count)
        {
            _data = data;
            Count = count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count { get; }
    }
