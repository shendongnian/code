    ObservableCollection<DeviceViewModel> _menuItems;
    public ObservableCollection<DeviceViewModel> MenuItems
    {
        get { return _menuItems; }
        set { this.SetProperty(ref _menuItems, value); }
    }
