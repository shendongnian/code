    private async void Savetoimage_Clicked(object sender, RoutedEventArgs e)
    {
        var piclib = Windows.Storage.KnownFolders.PicturesLibrary;
        foreach (var item in MyPrintPages.Items)
        {
            var rect = item as Rectangle;
            RenderTargetBitmap renderbmp = new RenderTargetBitmap();
            await renderbmp.RenderAsync(rect);
            var pixels = await renderbmp.GetPixelsAsync();
            var file = await piclib.CreateFileAsync("webview.png", Windows.Storage.CreationCollisionOption.GenerateUniqueName);
            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                byte[] bytes = pixels.ToArray();
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                 BitmapAlphaMode.Ignore,
                                 (uint)rect.Width, (uint)rect.Height,
                                 0, 0, bytes);
                await encoder.FlushAsync();
            }
        }
    }
