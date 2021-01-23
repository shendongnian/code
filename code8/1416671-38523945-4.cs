    public class DataField
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class PropertiesCollection
    {
        public PropertiesCollection(IEnumerable<DataField> collection)
        {
            _collection = collection;
        }
        private IEnumerable<DataField> _collection;
        public object this[string name]
        {
            get
            {
                return _collection.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.Value;
            }
        }
    }
    public class CustomList : ObservableCollection<DataField>
    {
        private PropertiesCollection _collection;
        public CustomList()
        {
            _collection = new PropertiesCollection(this);
        }
        public PropertiesCollection Properties
        {
            get
            {
                return _collection;
            }
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Properties)));
            base.OnCollectionChanged(e);
        }
    }
