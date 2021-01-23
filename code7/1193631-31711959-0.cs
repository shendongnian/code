    private List<TestItem> _initialItems = new List<TestItem>();
    public List<TestItem> Items
    {
        get
        {
            if (IsReadFilter)
            {
                return _initialItems.Where(i => i.IsRead).ToList();
            }
            return _initialItems;
        }
    }
    private bool _isReadFilter;
    public bool IsReadFilter
    {
        get { return _isReadFilter; }
        set
        {
            if (_isReadFilter != value)
            {
                _isReadFilter = value;
                OnPropertyChanged("IsReadFilter");
                OnPropertyChanged("Items");
            }
        }
    }
