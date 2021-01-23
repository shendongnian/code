    public static BitmapSource Convert(string s)
    {
        using (var ms = new MemoryStream(System.Convert.FromBase64String(s)))
        {
            return BitmapFrame.Create(
                BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
        }
    }
