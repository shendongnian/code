    public class DataField
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class CustomList : DynamicObject, INotifyCollectionChanged, INotifyPropertyChanged, IList<DataField>
    {
        private ObservableCollection<DataField> _innerCollection;
        public CustomList()
        {
            _innerCollection = new ObservableCollection<DataField>();
            _innerCollection.CollectionChanged += _innerCollection_CollectionChanged;
            ((INotifyPropertyChanged)_innerCollection).PropertyChanged += CustomList_PropertyChanged;
        }
        ~CustomList()
        {
            if (_innerCollection != null)
            {
                _innerCollection.CollectionChanged -= _innerCollection_CollectionChanged;
                ((INotifyPropertyChanged)_innerCollection).PropertyChanged -= CustomList_PropertyChanged;
            }
        }
        #region Dynamic
        public Object this[string name]
        {
            get
            {
                return _innerCollection.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.Value;
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return result != null;
        }
        #endregion
        #region INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void _innerCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var x = CollectionChanged;
            if (x != null)
            {
                x(sender, e);
            }
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void CustomList_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var x = PropertyChanged;
            if (x != null)
            {
                x(sender, e);
            }
        }
        #endregion
        #region IList
        public int Count
        {
            get
            {
                return _innerCollection.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return ((IList<DataField>)_innerCollection).IsReadOnly;
            }
        }
        public DataField this[int index]
        {
            get
            {
                return _innerCollection[index];
            }
            set
            {
                _innerCollection[index] = value;
            }
        }
        public int IndexOf(DataField item)
        {
            return _innerCollection.IndexOf(item);
        }
        public void Insert(int index, DataField item)
        {
            _innerCollection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _innerCollection.RemoveAt(index);
        }
        public void Add(DataField item)
        {
            _innerCollection.Add(item);
        }
        public void Clear()
        {
            _innerCollection.Clear();
        }
        public bool Contains(DataField item)
        {
            return _innerCollection.Contains(item);
        }
        public void CopyTo(DataField[] array, int arrayIndex)
        {
            _innerCollection.CopyTo(array, arrayIndex);
        }
        public bool Remove(DataField item)
        {
            return _innerCollection.Remove(item);
        }
        public IEnumerator<DataField> GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_innerCollection).GetEnumerator();
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomList c = new CustomList();
            dynamic d = c;
            object a;
            try
            {
                a = d.Invoke;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var newDataField = new DataField() { Name = "Invoke", Value = 1000 };
            c.Add(newDataField);
            a = d.Invoke;
            c.Remove(newDataField);
            try
            {
                a = d.SomeProperty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(a);
        }
    }
