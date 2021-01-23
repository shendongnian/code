    private void searchButton_Click(object sender, RoutedEventArgs e)
    {
        searchButton.Visibility = Visibility.Collapsed;
        AutoSearchBar.Visibility = Visibility.Visible;
    
        // slightly delay setting focus
        Task.Factory.StartNew(
            () => Dispatcher.RunAsync(CoreDispatcherPriority.Low,
                () => AutoSearchBar.Focus(FocusState.Programmatic)));
    }
