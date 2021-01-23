    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        // Register the current page as a share source.
        _dataTransferManager = DataTransferManager.GetForCurrentView();
        _dataTransferManager.DataRequested += OnDataRequested;
    }
    
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        // Unregister the current page as a share source.
        _dataTransferManager.DataRequested -= OnDataRequested;
    }
    
    protected void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
    {
        e.Request.Data.Properties.Title = "Some title";
        e.Request.Data.Properties.Description = "Some description"; // Optional 
        e.Request.Data.SetUri(new Uri("http://www.some_uri.com"));
    }
