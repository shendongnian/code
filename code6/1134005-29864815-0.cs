    public class MyList<T> : IEnumerable<T>
    {
        private List<T> itemCollection;
        public MyList()
        {
            this.itemCollection = null;
        }
        public void Add(T item)
        {
            this.itemCollection.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.itemCollection)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
