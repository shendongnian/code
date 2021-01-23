    private ObservableCollection<Track> _observableTracks;
    public ObservableCollection<Track> ObservableTracks
    {
        get { return _observableTracks; }
        set
        {
            _observableTracks = value;
            RaisePropertyChanged();
        }
    }
