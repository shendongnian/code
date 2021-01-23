    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        DataTransferManager dtManager = DataTransferManager.GetForCurrentView();
        dtManager.DataRequested += dtManager_DataRequested;
    }
    private async void dtManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
    {
        e.Request.Data.Properties.Title = "Code Samples";
        e.Request.Data.Properties.Description = "Here are some great code samples for Windows Phone.";
        e.Request.Data.SetWebLink(new Uri("http://code.msdn.com/wpapps"));
    }
    // Click Button to share Web Link
    private void btnShareLink_Click(object sender, RoutedEventArgs e)
    {
        Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
    }
