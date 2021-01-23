    public class Track
    {
        public string Title { get; set; }
    }
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Track> _observableTracks;
        public MainViewModel()
        {
            DoSomething = new RelayCommand(() => ObservableTracks = new ObservableCollection<Track>() { new Track { Title = "test" } });
        }
        public ObservableCollection<Track> ObservableTracks
        {
            get { return _observableTracks; }
            private set
            {
                _observableTracks = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand DoSomething { get; private set; }
    }
