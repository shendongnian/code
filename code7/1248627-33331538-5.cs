    private void DeleteSelectedItem(object sender, RoutedEventArgs e)
    {
        //items.RemoveAt(DetailsViews.SelectedIndex);
        items.Remove(SelectedItem);
    }
    private void grid_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
    {
        SelectedItem = (sender as FrameworkElement).DataContext as Person;
        FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
    }
