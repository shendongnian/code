    var writableBitmap = new WriteableBitmap(...);
    ...
    using (var stream = new InMemoryRandomAccessStream())
    {
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
        encoder.SetSoftwareBitmap(SoftwareBitmap.CreateCopyFromBuffer(
            writableBitmap.PixelBuffer,
            BitmapPixelFormat.Bgra8,
            writableBitmap.PixelWidth,
            writableBitmap.PixelHeight));
        await encoder.FlushAsync();
        stream.Seek(0);
        var bytes = new byte[stream.Size];
        await stream.AsStream().ReadAsync(bytes, 0, bytes.Length);
        var base64string = Convert.ToBase64String(bytes);
    }
 
