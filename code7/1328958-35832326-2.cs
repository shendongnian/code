    public static byte[] ImageToByte(BitmapImage imageSource)
    {
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(imageSource));
    
        using (var ms = new MemoryStream())
        {
            encoder.Save(ms);
            return ms.ToArray();
        }
    }
