    ObservableCollection<object> oMenuItemList { get; set; }
    
    ...
    
    oMenuItemList = GetContextMenuItems(sMenuItems);
    //the function
    private ObservableCollection<object> GetContextMenuItems(string sMenuItems)
    {
        //returns the ObservableCollection
    }
    _oContextMenu.ItemsSource = oMenuItemList;
    
