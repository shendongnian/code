     public class ListObservableCollection<T> : ObservableCollection<T>
    {
        public ListObservableCollection() : base()
        {
        }
        public ListObservableCollection(IEnumerable<T> collection) : base(collection)
        {
        }
        public ListObservableCollection(List<T> list) : base(list)
        {
        }
        public static implicit operator ListObservableCollection<T>(List<T> val)
        {
            return new ListObservableCollection<T>(val);
        }
    }
