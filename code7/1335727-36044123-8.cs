    foreach (var item in Menu)
    {
    	item.IsSelected = false; // reset to default
    }
    
    foreach(var selectedItem in Menulist.selecteditems)
    {
    	var deHavMenu = selectedItem as DeHavMenu;
    	if (devHavMenu != null)
    	{
    		devHavMenu.IsSelected = true; 
    	}
    }
