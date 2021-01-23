        public class MyObservableCollection<T> : ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public int Count { get { return _reference.Count; } }
        public bool IsReadOnly { get { return _reference.IsReadOnly; } }
        private readonly IList<T> _reference;
        public MyObservableCollection(IList<T> reference)
        {
            _reference = reference;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _reference.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            _reference.Add(item);
            SendNotification();
        }
        public void Clear()
        {
            _reference.Clear();
            SendNotification();
        }
        public bool Contains(T item)
        {
            return _reference.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _reference.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            var result = _reference.Remove(item);
            SendNotification();
            return result;
        }
        private void SendNotification()
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(new NotifyCollectionChangedAction()));
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("..."));
            }
        }
    }
