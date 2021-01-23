    ManagedTabItem selectedTabItem = this.mainTabControl.SelectedItem as ManagedTabItem;
    if (btnSelectAll == pressed)
    {
        selectedTabItem.Manager.SelectAll();
    }
    ...
