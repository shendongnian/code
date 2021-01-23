    await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
    {
        IBandClient client = await BandClientManager.Instance.ConnectAsync(...);
        ...
    });
