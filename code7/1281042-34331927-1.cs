    private Brush _gridBackground;
    public Brush GridBackground
    { 
        get { return _gridBackground; }
        set
        {
            _gridBackground = value;
            NotifyPropertyChanged();
        }
    }
