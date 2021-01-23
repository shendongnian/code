    private readonly ObservableRangeCollection<Details> _details = new ObservableRangeCollection<Details>();
    public IEnumerable<Details> Details
    {
        get { return _details; }
        set { _details.Replace(value); }
    }
