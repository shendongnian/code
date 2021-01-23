    using System;
    using System.Collections;
    using System.Collections.Generic;
    class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var decoratedList = new OverindexableListDecorator<int>(list);
            Console.WriteLine("-1st element is: {0}", decoratedList[-1]);
            Console.WriteLine("Element at index 3 is: {0}", decoratedList[3]);
            Console.WriteLine("6th element is: {0}", decoratedList[6]);
            Console.ReadKey();
        }
    }
    class OverindexableListDecorator<T> : IList<T>
    {
        private readonly IList<T> store;
        public OverindexableListDecorator(IList<T> collectionToWrap)
        {
            this.store = collectionToWrap;
        }
        public T this[int index]
        {
            get
            {
                int actualIndex = IndexModuloCount(index);
                return store[actualIndex];
            }
            set
            {
                int actualIndex = IndexModuloCount(index);
                store[actualIndex] = value;
            }
        }
        public void RemoveAt(int index)
        {
            var actualIndex = IndexModuloCount(index);
            store.RemoveAt(index);
        }
        public void Insert(int index, T item)
        {
            var actualIndex = IndexModuloCount(index);
            store.Insert(actualIndex, item);
        }
        private int IndexModuloCount(int i)
        {
            int count = this.Count;
            return ((i % count) + count) % count;
        }
        #region Delegate calls
        public IEnumerator<T> GetEnumerator()
        {
            return store.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            store.Add(item);
        }
        public void Clear()
        {
            store.Clear();
        }
        public bool Contains(T item)
        {
            return store.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            store.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            return store.Remove(item);
        }
        public int Count
        {
            get { return store.Count; }
        }
        public bool IsReadOnly
        {
            get { return store.IsReadOnly; }
        }
        public int IndexOf(T item)
        {
            return store.IndexOf(item);
        }
        #endregion
    }    
