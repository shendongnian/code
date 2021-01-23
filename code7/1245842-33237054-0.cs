    public class MyModel
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    
    public class MyViewModel : INotifyPropertyChanged
    {
        private readonly MyModel _model;
        private bool _displayProperty1;
     
        public MyViewModel(MyModel model)
        {
            _model = model;
        }
    
        public bool DisplayProperty1 
        { 
            get { return _displayProperty1; }
            set
            {
                _displayProperty1 = value;
                OnPropertyChanged("DisplayProperty1");
                OnPropertyChanged("PropertyToDisplay");
            }
        }
    
        public string PropertyToDisplay 
        { 
            get
            {
                return DisplayProperty1 ? _model.Property1 : _model.Property2;
            }
        }
    }
