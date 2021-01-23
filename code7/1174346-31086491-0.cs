    public class PageContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection _eventList;
    
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName)));
            }
        }
    
        public ObservableCollection EventList
        {
            get { return _eventList; }
            protected set
            {
                if (value.Equals(_eventList)) return;
                _eventList = value;
                OnPropertyChanged("EventList");
            }
        }
    }
