    DataTransferManager dtManager = DataTransferManager.GetForCurrentView();
    dtManager.DataRequested += (s, x) =>
    {
        x.Request.Data.Properties.Title = "You Title";
        x.Request.Data.Properties.Description = "YourBody";
        x.Request.Data.SetWebLink(new Uri("Your Link"));
    };
    Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
