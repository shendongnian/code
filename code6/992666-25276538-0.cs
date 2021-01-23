    double _actual;
    double _bench;
    public double Actual
    {
        get { return _actual; }
        set
        {
            _actual = value;
            OnPropertyChanged("Active");
        }
    }
    public double Bench
    {
        get { return _bench; }
        set
        {
            _bench = value;
            OnPropertyChanged("Active");
        }
    }
    public double Active
    {
        get { return Actual - Bench; }
    }
