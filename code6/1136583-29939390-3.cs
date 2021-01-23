    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private List<TElement> elements = new List<TElement>();
        public Grouping(TKey key)
        {
            Key = key;
        }
        public TKey Key { get; private set; }
        public IEnumerator<TElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(TElement element)
        {
            elements.Add(element);
        }
    }
