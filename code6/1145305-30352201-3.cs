    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        MenuItem item = FindMenuItem(mainMenu.MenuItems, keyData);
        if (item != null)
        {
            item.PerformClick();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    private MenuItem FindMenuItem(Menu.MenuItemCollection collection, Keys shortcut)
    {
        foreach (MenuItem item in collection)
        {
            if (item is MenuItemEx && (item as MenuItemEx).Shortcut == shortcut)
                return item;
            MenuItem sub = FindMenuItem(item.MenuItems, shortcut);
            if (sub != null)
                return sub;
        }
        return null;
    }
