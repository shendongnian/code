    public class ViewModelBase : INotifyPropertyChanged {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
