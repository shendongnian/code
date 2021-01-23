    public IEnumerable<Details> Details //note IEnumerable, no calling code needs to know its concrete type
    {
        get { return _details; }
        set
        {
            _details = value;
            NotifyPropertyChanged();
        }
    }
