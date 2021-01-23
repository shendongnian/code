    private Item _selectedItem;
    public Item SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem= value;
            NotifyPropertyChanged();
        }
    }
    private ObservableCollection<Item> _items;
    public ObservableCollection<Item> Items
    {
        get { return _items; }
        set
        {
            var tempList = value.Except(_items).ToList();
            
            _addresses = value;
            //if you are 100% sure only one item will be added at a time, you can add .First()
            //edit: please also keep in mind you need to check if there is actually an item that was added. when items are removed, this would also try to change the SelectedItem
            SelectedItem = tempList.First();
            NotifyPropertyChanged();
        }
    }
