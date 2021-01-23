    public BitmapSource ByteArrayToImage(byte[] buffer)
    {
        using (var stream = new MemoryStream(buffer))
        {
            return BitmapFrame.Create(stream,
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
