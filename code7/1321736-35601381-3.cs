    private ObservableCollection<ItemDto> _items=new ObservableCollection<ItemDto>();
    public ObservableCollection<ItemDto> Items
    {
        get { return _items; }
        set
        {
           _items= value;
           OnPropertyChanged("Items");
        }
    }
    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var i in collection)
        {
            Items.Add(i);
        }
    }
