    private void ContextMenu_OnOpened(object sender, RoutedEventArgs e)
    {
        var contextMenu = (ContextMenu)sender;
        var firstItem = (MenuItem)contextMenu.Items[0];
        var allItems = contextMenu.Items.Cast<MenuItem>().ToArray();
        foreach (var item in allItems)
        {
            if (item.Header.ToString() == "1.1" || item.Header.ToString() == "1.2")
            {
                firstItem.Items.Add(new MenuItem { Header = item.Header });
                contextMenu.Items.Remove(item);
            }
        }
    }
