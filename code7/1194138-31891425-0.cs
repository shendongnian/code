    public string Player
    {
        get { return Player; }
        set
        {
            Player = value;
            NotifyPropertyChanged("Player");
        }
    }
