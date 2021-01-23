    // using System.Runtime.InteropServices.WindowsRuntime;
    private async Task<string> ToBase64(Image control)
    {
        var bitmap = new RenderTargetBitmap();
        await bitmap.RenderAsync(control);
        return await ToBase64(bitmap);
    }
    private async Task<string> ToBase64(WriteableBitmap bitmap)
    {
        var bytes = bitmap.PixelBuffer.ToArray();
        return await ToBase64(bytes, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight);
    }
    private async Task<string> ToBase64(StorageFile bitmap)
    {
        var stream = await bitmap.OpenAsync(Windows.Storage.FileAccessMode.Read);
        var decoder = await BitmapDecoder.CreateAsync(stream);
        var pixels = await decoder.GetPixelDataAsync();
        var bytes = pixels.DetachPixelData();
        return await ToBase64(bytes, (uint)decoder.PixelWidth, (uint)decoder.PixelHeight, decoder.DpiX, decoder.DpiY);
    }
    private async Task<string> ToBase64(RenderTargetBitmap bitmap)
    {
        var bytes = (await bitmap.GetPixelsAsync()).ToArray();
        return await ToBase64(bytes, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight);
    }
    private async Task<string> ToBase64(byte[] image, uint height, uint width, double dpiX = 96, double dpiY = 96)
    {
        // encode image
        var encoded = new InMemoryRandomAccessStream();
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, height, width, dpiX, dpiY, image);
        await encoder.FlushAsync();
        encoded.Seek(0);
        // read bytes
        var bytes = new byte[encoded.Size];
        await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);
        // create base64
        return Convert.ToBase64String(bytes);
    }
    private async Task<ImageSource> FromBase64(string base64)
    {
        // read stream
        var bytes = Convert.FromBase64String(base64);
        var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();
        // decode image
        var decoder = await BitmapDecoder.CreateAsync(image);
        image.Seek(0);
        // create bitmap
        var output = new WriteableBitmap((int)decoder.PixelHeight, (int)decoder.PixelWidth);
        await output.SetSourceAsync(image);
        return output;
    }
