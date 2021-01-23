    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }
    
    private IEnumerable<JsonObject> _items;
    public IEnumerable<JsonObject> Items
    {
        get { return _items; }
        set
        {
            if (_items != value)
            {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }
    }
