    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        DataTransferManager.GetForCurrentView().DataRequested+= MainPage_DataRequested;
    }
 
    private async void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        var deferral = args.Request.GetDeferral();
        var bitmap = new RenderTargetBitmap();
        await bitmap.RenderAsync(canvas);
 
        // 1. Get the pixels
        IBuffer pixelBuffer = await bitmap.GetPixelsAsync();
        byte[] pixels = pixelBuffer.ToArray();
 
        // 2. Write the pixels to a InMemoryRandomAccessStream
        var stream = new InMemoryRandomAccessStream();
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, stream);
 
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, 96, 96,
            pixels);
 
        await encoder.FlushAsync();
        stream.Seek(0);
 
        // 3. Share it
        args.Request.Data.SetBitmap(RandomAccessStreamReference.CreateFromStream(stream));
        args.Request.Data.Properties.Description = "description";
        args.Request.Data.Properties.Title = "title";
        deferral.Complete();
    }
