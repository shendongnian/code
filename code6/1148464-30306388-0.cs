    public class Bag<Item> : IEnumerable<Item>
    {
        ...
        [IndexerName("MyIndexer")]
        public Item this[int i]
        {
            get
            {
                return ((ListIterator<Item>)GetEnumerator ())[i];
            }
        }
        ...
    }
