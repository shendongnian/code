    public class AllTracksViewModel
    {
        private ObservableCollection<Track> _trackListObservable;
        public ObservableCollection<Track> TrackListObservable
        {
           get { return _trackListObservable; }
           set { 
                 _trackListObservable = value;                 
               }
        }
    
        public AllTracksViewModel()
        {
             FillData();
        }
        private void FillData()
        {
           _trackListObservable = new ObservableCollection<Track>();
            for (int i = 0; i < 30; i++)
            {
               TrackListObservable.Add(new Track() { Title = "Ben & Joseph " + i.ToString(), 
                                                                     Artist = "Albahari" });
            }   
        }
    }
