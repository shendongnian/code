    private ObservableCollection<string> _menuItems;
    public ObservableCollection<string> MenuItems
    {
        get { return _menuItems; }
        set
        {
            if (_menuItems == value) return;
            _menuItems = value;
            RaisePropertyChanged(() => MenuItems);
        }
    }
