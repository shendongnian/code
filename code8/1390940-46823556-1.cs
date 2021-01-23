    private NavigationMenuItem _selectedMenuItem;
    public NavigationMenuItem SelectedMenuItem
    {
        get { return _selectedMenuItem; }
        set
        {
            _selectedMenuItem = val;
            AsyncRunner.Run(YourAsyncMethod(_selectedMenuItem));            
        }
    }
