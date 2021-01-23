    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
        dataTransferManager.DataRequested += ShareData;
    }
    private async void ShareData(DataTransferManager sender, DataRequestedEventArgs e)
    {
        try
        {
            DataRequest request = args.Request;
            var deferral = request.GetDeferral();
            request.Data.Properties.Title = "Title";
            request.Data.Properties.Description = "Description";
            request.Data.SetText("The text to share");
            deferral.Complete();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
    private void btnShareLink_Click(object sender, RoutedEventArgs e)
    {
        Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
    }
