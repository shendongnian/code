    private void ContextMenu_OnOpened(object sender, RoutedEventArgs e)
    {
        var contextMenu = (ContextMenu)sender;
        var firstItem = (MenuItem)contextMenu.Items[0];
        // Must create new array of existing menu items
        // to be able to edit existing context menu during loop enumeration.
        var allItems = contextMenu.Items.Cast<MenuItem>().ToArray();
        foreach (var item in allItems)
        {
            if (item.Header.ToString() == "1.1" || item.Header.ToString() == "1.2")
            {
                // Add menu item with the same header into another item as sub-item
                firstItem.Items.Add(new MenuItem { Header = item.Header });
                // Remove item from root level.
                contextMenu.Items.Remove(item);
            }
        }
    }
