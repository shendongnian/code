    public class NonZeroList<T> : IList<T>
    {
        private int startIndex;
        private List<T> inner;
        public NonZeroList(int startIndex, IEnumerable<T> content)
        {
            this.startIndex = startIndex;
            inner = content.ToList();
        }
        public NonZeroList(int startIndex)
        {
            this.startIndex = startIndex;
            inner = new List<T>();
        }
        public T this[int i]
        {
            get
            {
                return inner[i - startIndex];
            }
            set
            {
                inner[i - startIndex] = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T i in inner)
                yield return i;
            yield break;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return inner.GetEnumerator();
        }
        public int IndexOf(T item)
        {
            return inner.IndexOf(item) + startIndex;
        }
        public void Insert(int index, T item)
        {
            inner.Insert(index - startIndex, item);
        }
        public void RemoveAt(int index)
        {
            inner.RemoveAt(index - startIndex);
        }
        public void Add(T item)
        {
            inner.Add(item);
        }
        public void Clear()
        {
            inner.Clear();
        }
        public bool Contains(T item)
        {
            return inner.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            inner.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return inner.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            return inner.Remove(item);
        }
    }
