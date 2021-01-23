    public class SortedSinglyLinkedList<T>
    {
        private readonly IComparer<T> _comparer;
        // ...
        public SortedSinglyLinkedList()
        {
            _comparer = Comparer<T>.Default; // use the default.
            // ...
        }
        public SortedSinglyLinkedList(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            // ...
        }
    }
    
