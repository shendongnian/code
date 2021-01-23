    public int Year
    {
        get { return _year; }
        set
        {
            _year = value;
            OnPropertyChanged();
        }
    }
