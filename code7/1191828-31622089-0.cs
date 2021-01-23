    MenuItems =  await AppWinService.GetMenuEntriesAsync();   
    if ((MenuItems != null) && (MenuItems.Any())
    {
       ItemSource = new ObservableCollection<AlphaKeyGroup<Menu>>(
                                              (AlphaKeyGroup<Menu>.CreateGroups(MenuItems,
                                               CultureInfo.CurrentUICulture, 
                                               s => s.MenuName, 
                                               true)));
      ((CollectionViewSource)Resources["MenuGroups"]).Source = ItemSource;
    }
    else 
    { 
       MessageBox.Show("Failure to get data"); 
    }
