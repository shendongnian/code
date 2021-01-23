    public class Data:INotifyPropertyChanged
    {
        public ObservableCollection<MyRecord> Items
        {
           get{
                return _items;
           }
           set{
                _items=value;
                OnProperyChanged("Items")
            }
        }
        public Data()
        {
            Items = new ObservableCollection<MyRecord>()
            {
                    new MyRecord(){Title:"First",IsEnable:false}),
                    new MyRecord(){Title:"Second",IsEnable:false})
            };
        }
        //---------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnProperyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var handler= PropertyChanged ;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class MyRecord:INotifyPropertyChanged
    {
        private int _title;
        private bool _isEnable;
    
        public int Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title= value;
                OnProperyChanged("Title")
            }
        }
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable= value;
                OnProperyChanged("IsEnable")
            }
        }
        
        //---------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnProperyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var handler= PropertyChanged ;
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
