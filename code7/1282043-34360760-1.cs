    private static async Task<BitmapImage> ConvertImage(byte[] imageSource)
    {
        if (imageSource == null)
        {
            return null;
        }
        MemoryStream memoryStream = new MemoryStream(imageSource);
        using (IRandomAccessStream randomAccessStream = memoryStream.AsRandomAccessStream())
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(randomAccessStream);
            PixelDataProvider provider = await decoder.GetPixelDataAsync(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, new BitmapTransform(), ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
            byte[] pixels = provider.DetachPixelData();
            //Each Pixel is composed of 4 bytes [0]: Blue, [1]: Green, [2]: Red, [3] Alpha
            //Do Here your magic with this pixels byte array
            using (InMemoryRandomAccessStream memoryRandomAccessStream = new InMemoryRandomAccessStream())
            {
                var imageBytes = await EncodeImageBytes(memoryRandomAccessStream, decoder, pixels);
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    BitmapImage image = new BitmapImage();
                    await stream.WriteAsync(imageBytes.AsBuffer());
                    stream.Seek(0);
                    image.SetSource(stream);
                    return image;
                }
            }
        }
    }
    private static async Task<byte[]> EncodeImageBytes(InMemoryRandomAccessStream memoryRandomAccessStream, BitmapDecoder decoder, byte[] pixels)
    {
        BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, memoryRandomAccessStream);
        encoder.SetPixelData(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, decoder.PixelWidth, decoder.PixelHeight, 96, 96, pixels);
        await encoder.FlushAsync();
        var imageBytes = new byte[memoryRandomAccessStream.Size];
        await memoryRandomAccessStream.ReadAsync(imageBytes.AsBuffer(), (uint) memoryRandomAccessStream.Size, InputStreamOptions.None);
        return imageBytes;
    }
