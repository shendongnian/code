    public class PlaylistVM: System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<CompositionVM> _songs;
        public ObservableCollection<CompositionVM> Songs
        {
            get
            {
                return _songs;
            }
            set
            {
                if(_songs != value)
                {
                    //if old value not null, unhook event
                    if (_songs != null)
                    {
                        _songs.CollectionChanged -= FireSongsChanged;
                    }
                    //change the value
                    _songs = value;
                    //if new value !=null, then attach handlers.
                    if (_songs != null)
                    {
                        _songs.CollectionChanged += FireSongsChanged;
                    }
                    //this will fire the 
                    FireSongsChanged(null, null);
                }
                
            }
        }
        void FireSongsChanged(object sender, EventArgs e)
        {
            //the collection of songs has changed, tell UI that it needs to requery the list of ordered songs.
            var ev = this.PropertyChanged;
            if (ev != null)
            {
                ev(this, new System.ComponentModel.PropertyChangedEventArgs("OrderedSongs"));
            }
        }
        //set the UI to bind to the following list of the songs. ordered by name.
        public IEnumerable<CompositionVM> OrderedSongs
        {
            get
            {
                return Songs.OrderBy(song => song.Name);
            }
        }
    
    }
