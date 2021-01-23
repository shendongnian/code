    private int _albumID;
    [Column(CanBeNull = false)]
    public int AlbumID
    {
        get { return _albumID; }
        set
        {
            if (_albumID != value)
            {
                NotifyPropertyChanging();
                _albumID = value;
                NotifyPropertyChanged();
            }
        }
    }
