    private void bnFeedDel_Click(object sender, RoutedEventArgs e)
	{
		TruckServiceClient service = new TruckServiceClient();
		service.DelFeedAsync(new FeedView
		{
            // Of course you may want to check for nulls etc...
			Id = ((ClientItems)lbFeed.SelectedItem).FId
	    });
	 }
