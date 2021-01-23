    private async void loadmore_clicked(object sender, RoutedEventArgs e)
    {
        loadingMessage.Visibility = Visibility.Visible;
        await LoadMoreItemsForLongListAsync();
        loadingMessage.Visibility = Visibility.Collapsed;
    }
