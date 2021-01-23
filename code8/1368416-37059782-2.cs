    public async Task<string> ToBase64String(WriteableBitmap writableBitmap)
    {
        using (var stream = new InMemoryRandomAccessStream())
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            encoder.SetSoftwareBitmap(SoftwareBitmap.CreateCopyFromBuffer(
                writableBitmap.PixelBuffer,
                BitmapPixelFormat.Bgra8,
                writableBitmap.PixelWidth,
                writableBitmap.PixelHeight));
            await encoder.FlushAsync();
            var bytes = new byte[stream.Size];
            await stream.AsStream().ReadAsync(bytes, 0, bytes.Length);
            return Convert.ToBase64String(bytes);
        }
    }
