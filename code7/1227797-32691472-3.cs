    public static byte[] ImageToArray(BitmapSource image)
    {
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        using (var stream = new MemoryStream())
        {
            encoder.Save(stream);
            return stream.ToArray();
        }
    }
