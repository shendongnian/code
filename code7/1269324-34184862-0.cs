    await Windows.ApplicationModel.Core.CoreApplication.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
    {
        IBandClient client = await BandClientManager.Instance.ConnectAsync(...);
        ...
    });
