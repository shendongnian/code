    public Uri currentImageNotifier
    {
        get { return CurrentImage; }
        set
        {
            CurrentImage = value;
            RaisePropertyChanged("CurrentImage");
        }
    }
