    public class CountedSet<T> : ICollection<T> 
    {
        readonly IEqualityComparer<T> comparer;
        readonly Dictionary<T, int> dictionary;
        int totalCount = 0;
        int version = 1;
        public CountedSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            if (collection == null)
                collection = Enumerable.Empty<T>();
            this.comparer = comparer;
            int capacity;
            var coll = collection as ICollection<T>;
            if (coll != null)
                capacity = coll.Count;
            else
                capacity = 0;
            dictionary = new Dictionary<T, int>(capacity, comparer);
            totalCount = 0;
            foreach (var item in collection)
                Add(item);
        }
        public CountedSet(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }
        public CountedSet()
            : this(Enumerable.Empty<T>())
        {
        }
        int ComputeTotalCount()
        {
            int count = 0;
            foreach (var pair in dictionary)
                count += pair.Value;
            return count;
        }
        [Conditional("DEBUG")]
        void AssertValid()
        {
            Debug.Assert(totalCount >= 0, "totalCount >= 0");
            Debug.Assert(totalCount == ComputeTotalCount());
            foreach (var pair in dictionary)
                Debug.Assert(pair.Value > 0, "pair.Value > 0");
        }
        public void AddRange(IEnumerable<T> other)
        {
            foreach (var item in other)
                Add(item);
        }
        public void RemoveRange(IEnumerable<T> other) 
        {
            foreach (var item in other)
                Remove(item);
        }
        
        #region ICollection<T> Members
        public void Add(T item)
        {
            int itemCount;
            if (dictionary.TryGetValue(item, out itemCount))
            {
                Debug.Assert(itemCount > 0, "itemCount > 0");
                dictionary[item] = itemCount + 1;
            }
            else
            {
                dictionary[item] = 1;
            }
            version++;
            totalCount++;
            AssertValid();
        }
        public void Clear()
        {
            dictionary.Clear();
            totalCount = 0;
            version++;
        }
        public bool Contains(T item)
        {
            return dictionary.ContainsKey(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int CountItem(T item)
        {
            int count;
            if (dictionary.TryGetValue(item, out count))
                return count;
            return 0;
        }
        public int Count { get { return totalCount; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(T item)
        {
            int itemCount;
            if (dictionary.TryGetValue(item, out itemCount))
            {
                Debug.Assert(itemCount > 0, "itemCount > 0");
                itemCount--;
                if (itemCount < 1)
                    dictionary.Remove(item);
                else
                    dictionary[item] = itemCount;
                totalCount--;
                version++;
                AssertValid();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            int initialVersion = this.version;
            foreach (var pair in this.dictionary)
                for (int i = 0; i < pair.Value; i++)
                {
                    if (initialVersion != this.version)
                    {
                        throw new InvalidOperationException("collection was modified");
                    }
                    yield return pair.Key;
                }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
