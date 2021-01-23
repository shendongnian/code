    var dataPackageView = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Bitmap))
    {
        IRandomAccessStreamReference imageReceived = null;
        try
        {
            imageReceived = await dataPackageView.GetBitmapAsync();
        }
        catch (Exception ex)
        {
        }
    
