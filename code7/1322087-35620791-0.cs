    private IEnumerable<string> _Current;
    public IEnumerable<string> Current
    {
        get { return this._Current; }
        set
        {
            this._Current = value;
            _currentCount = _Current.Count();
            this.OnPropertyChanged("Current");
            this.OnPropertyChanged("CurrentCount");
            this.OnPropertyChanged("CurrentItems");
        }
    }
    private int _currentCount;
    public int CurrentCount
    {
        get { return _currentCount; }            
    }
    // or create a class instead of anonymous objects
    public IEnumerable<object> CurrentItems
    {
        get { return Current.Select((item, idx) => new { Item = item, Row = idx / 2, Column = idx % 2 }); }
    }
