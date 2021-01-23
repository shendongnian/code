What I am suggesting you is just have separate class as your ViewModel e.g. NetWorkViewModel and inside your ViewModel create a property of your EXISTING OBJECT type and change the bindings in XAML as well.
    public class NetworkViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Network _model;
        public Network Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
            
        private void OnPropertyChanged(string propertyName) 
        {  }
    }
    
    public class Network : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
    
        private void OnPropertyChanged(string propertyName)
        { }
    }
