    private void ModellMenuEdit_Click(object sender, RoutedEventArgs e)
    {
        var menuFlyoutItem = sender as MenuFlyoutItem;
        Modell datacontext;
        if (menuFlyoutItem != null)
        {
            datacontext = menuFlyoutItem.DataContext as Modell;
        }
        Frame.Navigate(typeof(ModellEdit));
    }
