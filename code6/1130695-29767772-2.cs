    public static BitmapSource BitmapFromBase64(string base64String)
    {
        var bytes = Convert.FromBase64String(base64String);
        using (var stream = new MemoryStream(bytes))
        {
            return BitmapFrame.Create(stream,
                BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
