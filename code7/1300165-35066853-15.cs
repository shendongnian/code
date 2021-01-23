    public class UpdatedViewModel:BaseObservableObject
    {
        public ObservableCollection<ColumnDescriptor> ColumnHeaders 
        {
            get { return _columnHeaders; } 
            set
            {
                if (_columnHeaders == value)
                    return;
                _columnHeaders = value;
                OnPropertyChanged(() => ColumnHeaders);
            }
        }
        public ObservableCollection<MappedCollection<MappedObject>> Data
        {
            get { return _data; }
            set
            {
                if (_data == value)
                    return;
                _data = value;
                OnPropertyChanged(() => Data);
            }
        }
        private ObservableCollection<ColumnDescriptor> _columnHeaders;
        private ObservableCollection<MappedCollection<MappedObject>> _data;
        public UpdatedViewModel()
        {
            //ColumnHeaders = new ObservableCollection<string>();
            //ColumnHeaders.Add("String Column");
            //ColumnHeaders.Add("Boolean Column");
            ColumnHeaders = new ObservableCollection<ColumnDescriptor>
            {
                new ColumnDescriptor {HeaderText = "String Column", DisplayMember = "StringColumn", ColumnTemplateTemplateKey = typeof(String)},
                new ColumnDescriptor {HeaderText = "Bolean Column", DisplayMember = "BoleanColumn", ColumnTemplateTemplateKey = typeof(Boolean)},
            };
            Data = new ObservableCollection<MappedCollection<MappedObject>>();
            var mappedCollection = new MappedCollection<MappedObject>();
            for(int i = 0; i < 5; i++)
            {
                //row.Add("cell " + i);
                //row.Add(i % 2 == 0 ? true : false);
                mappedCollection.MappedObjects.Add(new MappedObject { StringColumn = string.Format("cell:{0}", i), BoleanColumn = i % 2 == 0 });
                
            }
            Data.Add(mappedCollection);
        }
    }
    public class MappedCollection<T>:BaseObservableObject
    {
        private ObservableCollection<T> _mappedObjects;
        public MappedCollection()
        {
            MappedObjects = new ObservableCollection<T>();
        }
        public ObservableCollection<T> MappedObjects
        {
            get { return _mappedObjects; }
            set
            {
                _mappedObjects = value;
                OnPropertyChanged();
            }
        }
    }
    public class MappedObject:BaseObservableObject
    {
        private object _stringColumn;
        private object _boleanColumn;
        public object StringColumn
        {
            get { return _stringColumn; }
            set
            {
                _stringColumn = value;
                OnPropertyChanged();
            }
        }
        public object BoleanColumn
        {
            get { return _boleanColumn; }
            set
            {
                _boleanColumn = value;
                OnPropertyChanged();
            }
        }
    }
