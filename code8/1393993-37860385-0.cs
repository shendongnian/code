    private readonly ReactiveList<Item> _list = new ReactiveList<Item>();
    
    private readonly ObservableAsPropertyHelper<decimal> _sum;
    public decimal Sum {
        get { return _sum.Value; }
    }
    
    // in constructor
    _sum = _list
        .Changed
        .Select(_ => _list.Select(i => i.Value).Sum())
        .ToProperty(this, x => x.Sum);
