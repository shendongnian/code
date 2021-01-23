    public class Collection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
    {
        public Collection();
        public Collection(IList<T> list);
        public T this[int index] { get; set; }
        public int Count { get; }
        protected IList<T> Items { get; }
        public void Add(T item);
        public void Clear();
        public bool Contains(T item);
        public void CopyTo(T[] array, int index);
        public IEnumerator<T> GetEnumerator();
        public int IndexOf(T item);
        public void Insert(int index, T item);
        public bool Remove(T item);
        public void RemoveAt(int index);
        protected virtual void ClearItems();
        protected virtual void InsertItem(int index, T item);
        protected virtual void RemoveItem(int index);
        protected virtual void SetItem(int index, T item);
    }
