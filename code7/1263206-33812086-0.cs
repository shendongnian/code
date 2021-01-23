    static readonly byte[] PngBytes = {
        137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1,
        8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0,
        0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115,
        0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 0, 24, 116, 69, 88, 116, 83,
        111, 102, 116, 119, 97, 114, 101, 0, 112, 97, 105, 110, 116, 46, 110, 101, 116, 32, 52,
        46, 48, 46, 51, 140, 230, 151, 80, 0, 0, 0, 13, 73, 68, 65, 84, 24, 87, 99, 248, 255, 
        255, 255, 127, 0, 9, 251, 3, 253, 5, 67, 69, 202, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66,
        96, 130
    };
    
    public static async Task<byte[]> ConvertToPngBytes(this WriteableBitmap bitmap)
    {
        using (var memoryStream = new InMemoryRandomAccessStream())
        {
            await memoryStream.WriteAsync(PngBytes.AsBuffer());
            memoryStream.Seek(0);
                    
            BitmapEncoder encode = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId,
                memoryStream);
            byte[] buffer = bitmap.PixelBuffer.ToArray();
            encode.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, 
                (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, 96.0, 96.0, buffer);
            await encode.FlushAsync();
            var stream = memoryStream.AsStream();
            stream.Seek(0, SeekOrigin.Begin);
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, result.Length);
            return result;
        }
    }
