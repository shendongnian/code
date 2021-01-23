    public class AllTracksViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Track> trackListObservable;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Track> TrackListObservable {
          get { return trackListObservable; }
          set {
            trackListObservable = value;
            if(PropertyChanged!=null) {
              PropertyChanged(this, new PropertyChangedEventArgs("TrackListObservable"));
            }
          }
    }
    
        public AllTracksViewModel()
        {
            TrackListObservable = new ObservableCollection<Track>();
        }
    }
