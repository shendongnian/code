    public class SomeClass : INotifyPropertyChanged
    {
        public SomeClass()
        {
            CollectionOfObjects = new ObservableCollection<MyClass>();
        }
        public int Field1 
        {
            get 
            {
                return _field1;
            }
            set
            {
                if(_field1 != value)
                {
                    _field1 = value;
                    PropertyChanged(new PropertyChangedEventArgs("Field1"));
                }
            }
        }
        public ObservableCollection<MyClass> CollectionOfObjects 
        {
            get 
            {
                return _collectionOfObjects;
            }
            set
            {
                if(_collectionOfObjects != value)
                {
                    _collectionOfObjects = value;
                    PropertyChanged(new PropertyChangedEventArgs("CollectionOfObjects"));
                }
            }
        }
        public string Description
        {
            get 
            {
                return _description;
            }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    PropertyChanged(new PropertyChangedEventArgs("Description"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate {}
        private int _field1;
        private ObservableCollection<MyClass> _collectionOfObjects;
        private string _description;
    }
