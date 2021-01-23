    var displayInformation = DisplayInformation.GetForCurrentView();
    ccDraw.Measure(imageSize);
    ccDraw.UpdateLayout();
    ccDraw.Arrange(new Rect(0, 0, imageSize.Width, imageSize.Height));
    var renderTargetBitmap = new RenderTargetBitmap();
    await renderTargetBitmap.RenderAsync(ccDraw, Convert.ToInt32(imageSize.Width), Convert.ToInt32(imageSize.Height));
    var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
    var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Screen.jpg", CreationCollisionOption.ReplaceExisting);
    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
          var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, fileStream);
          encoder.SetPixelData(
                  BitmapPixelFormat.Bgra8,
                  BitmapAlphaMode.Ignore,
                  (uint)renderTargetBitmap.PixelWidth,
                  (uint)renderTargetBitmap.PixelHeight,
                  displayInformation.LogicalDpi,
                  displayInformation.LogicalDpi,
                  pixelBuffer.ToArray());
          await encoder.FlushAsync();
    }
