    public class BookViewModel : INotifyPropertyChanged
    {
            
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        private ObservableCollection<Track> _observableTracks;
        public ObservableCollection<Track> ObservableTracks
        {
            get { return _observableTracks; }
            set
            {
                _observableTracks = value;
                NotifyPropertyChanged("ObservableTracks");
            }
        }
    }
