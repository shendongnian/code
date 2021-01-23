    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        //  This needs some null checking and a try catch, but this is the guts of it. 
        var menuItem = e.OriginalSource as MenuItem;
        //  Since we used ItemContainerStyle to give each ComboBoxItem its own 
        //  personal ContextMenu, each ContextMenu will have its PlacementTarget
        //  set to the ComboBoxItem that owns it. 
        var cbItem = (menuItem.Parent as ContextMenu).PlacementTarget as ComboBoxItem;
        //  ???
        //var dataItem = cbItem.DataContext;
    }
