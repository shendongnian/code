    private void loadmore_clicked(object sender, RoutedEventArgs e)
    {
        loadingMessage.Visibility = Visibility.Visible;
        Task.Run( () => 
             LoadMoreItemsForLongList() // loading more items for the LongListSelector's ItemSource
        ).ContinueWith( () =>   
             loadingMessage.Visibility = Visibility.Collapsed;
        );
    }
