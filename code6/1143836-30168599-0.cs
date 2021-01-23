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
    In the example we use the SetUri to share an Uri. There are many different shares which is used to share different things:
    
     SetBitmap(RandomAccessStreamReference value)
    
    SetApplicationLink(Uri value)
    
    SetData(string formatId, object value)
    
    SetDataProvider(string formatId, DataProviderHandler delayRenderer)
    
    SetStorageItems(IEnumerable value)
    
    SetStorageItems(IEnumerable value, bool readOnly)
    
    SetText(string value)
    
    SetUri(Uri value)
    
    SetWebLink(Uri value)
    
    SetHtmlFormat(string value)
    
    SetRtf(string value)
