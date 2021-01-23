    public class Product : IDataErrorInfo, INotifyPropertyChanged {
        string _name;
        [DataMember()]
        public string Name{
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
    
        //...Other code removed for brevity
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
