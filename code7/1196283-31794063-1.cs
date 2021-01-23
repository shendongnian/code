    private void MainTabControl_SelectionChanged(object sender, TabControlSelectionChangedEventArgs e)
    {
        // Turn it off and see if it needs to be enabled.
        this.FileSubMenu.IsEnabled = false;
        var newTabItem = e.NewSelectedItem as DXTabItem;
        if (newTabItem != null)
        {
            var tabView = newTabItem.Content as UserControl;
            if (tabView != null)
            {
                var tabViewModel = tabView.ViewModel;
                if (tabViewModel != null)
                {
                    this.FileSubMenu.DataContext = tabViewModel;
                    this.FileSubMenu.IsEnabled = true;
                }
            }
        }
    }
