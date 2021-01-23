    public class MainUIModel : INotifyPropertyChanged
    {
        ObservableCollection<RandomList> _randomList;
        public ObservableCollection<RandomList> randomList
        {
            get { return _randomList; }
            set
            {
                if (_randomList != value)
                    _randomList = value;
                OnPropertyChanged("randomList");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
