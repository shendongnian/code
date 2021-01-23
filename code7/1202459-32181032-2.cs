    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        var dataPackage = new DataPackage { RequestedOperation = DataPackageOperation.Copy };
        dataPackage.SetText("Hello World!");
        Clipboard.SetContent(dataPackage);
        getText();
    });
    private async void getText()
    {
        string t = await Clipboard.GetContent().GetTextAsync();
    }
