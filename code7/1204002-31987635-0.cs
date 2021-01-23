    public string BackgroundColor
    {
        get { return _backgroundColor; }
        set
        {
            if (_backgroundColor== value) return;
            _backgroundColor = value;
            NotifyPropertyChanged("BackgroundColor");
        }
    }
