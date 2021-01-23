    public ObservableCollection<MenuItem> MenuItemsCollection { get; set; } = new ObservableCollection<MenuItem>
    {
        new MenuItem { Header = "1.0" },
        new MenuItem { Header = "1.1" },
        new MenuItem { Header = "1.2" },
        new MenuItem { Header = "2.0" },
        new MenuItem { Header = "3.0" },
    };
    
    private void ContextMenu_OnOpened(object sender, RoutedEventArgs e)
    {
        var contextMenu = (ContextMenu)sender;
        var firstItem = (MenuItem)contextMenu.Items[0];
        var allItems = this.MenuItemsCollection.ToArray();
        foreach (var item in allItems)
        {
            if (item.Header.ToString() == "1.1" || item.Header.ToString() == "1.2")
            {
                firstItem.Items.Add(item);
                this.MenuItemsCollection.Remove(item);
            }
        }
    }
