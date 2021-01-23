    private static void SaveImage(BitmapFrame data, Stream saveStream)
    {
        var encoder = BitmapEncoder.Create(data.Decoder.CodecInfo.ContainerFormat);
        encoder.Frames.Add(data);
        using (var memoryStream = new MemoryStream())
        {
            encoder.Save(memoryStream);
            memoryStream.Position = 0;
            memoryStream.CopyTo(saveStream);
        }
    }
