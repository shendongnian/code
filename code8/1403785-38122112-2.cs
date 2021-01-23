    List<Item> _list = new List<Item>();
    
    public ObservableCollection<Item> Collection => new ObservableCollection<Item>(_list);
    public ObservableCollection<Item> Collection2 =>
        new ObservableCollection<Item>(_list.Skip(0));
