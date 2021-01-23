    private async Task<String> ToBase64(byte[] image, uint height, uint width, double dpiX = 96, double dpiY= 96)
    {
        var encoded = new InMemoryRandomAccessStream();
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, height, width, dpiX, dpiY, image);
        await encoder.FlushAsync();
        encoded.Seek(0);
        var bytes = new byte[encoded.Size];
        await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);
        return Convert.ToBase64String(bytes);
    }
    private async Task<String> ToBase64(WriteableBitmap bitmap)
    {
        var bytes = bitmap.PixelBuffer.ToArray();
        return await ToBase64(bytes, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight);
    }
    private async void myBtn_Click(object sender, RoutedEventArgs e)
    {
            
        StorageFile myImage = await GetFileAsync();
        ImageProperties properties = await myImage.Properties.GetImagePropertiesAsync();
        WriteableBitmap bmp = new WriteableBitmap((int)properties.Width, (int)properties.Height);
        bmp.SetSource(await myImage.OpenReadAsync());
        String dataStr=await ToBase64(bmp);
        String fileType = myImage.FileType.Substring(1);
        String str = "<figure><img src=\"data:image/"+myImage.FileType+";base64,"+dataStr+"\" alt =\"aaa\" height=\"400\" width=\"400\"/><figcaption>Figure  : thumb_IMG_0057_1024</figcaption></figure>";
        myWebView.NavigateToString(str);
    }
    private async Task<StorageFile> GetFileAsync()
    {
        StorageFile myImage = await ApplicationData.Current.LocalFolder.GetFileAsync("myImage.jpg");
        return myImage;
    }
