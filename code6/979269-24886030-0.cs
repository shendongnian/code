    //Suppose menu is the name of your Menu (or ContextMenu)
    bool suppressOpen = true;
    menu.AddHandler(MenuItem.SubmenuOpenedEvent, new RoutedEventHandler((s, e) =>
    {
       if (suppressOpen) ((MenuItem)e.Source).IsSubmenuOpen = false;
       else suppressOpen = true;
    }));
    menu.AddHandler(MenuItem.PreviewMouseDownEvent, 
                    new MouseButtonEventHandler((s, e) =>
    {
       suppressOpen = false;
       ((MenuItem)e.Source).IsSubmenuOpen = true;
    }));
