    public class Model: INotifyPropertyChanged
    {
        private string _property;
        public string Property
        {
            get { return _property; }
            set
            {
                _property = value;
                OnPropertyChanged();
            }
        }
    }
    public class ViewModel
    {
        public string BindProperty
        {
            get { return modelInstance.Property; }
            set
            {
                modelInstance.Property = value;
                OnPropertyChanged();
            }
        }
        public ViewModel()
        {
            modelInstance.PropertyChanged += Model_PropertyChanged;
        }
        void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // forward change notification to View
            if(e.PropertyName == "Property")
                OnPropertyChanged("BindProperty");
        }
    }
