    public string MyProperty
    {
        get { return _myProperty; }
        set { _myProperty = value; OnPropertyChanged(); }
    }
