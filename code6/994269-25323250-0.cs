    private List<string> _bar;
    ...
    public void Add(string item)
    {
        _bar.Add(item);
    }
    
    public IEnumerable<string> Bar
    {
        get { return new ReadOnlyCollection<string>(_bar); }
    }
