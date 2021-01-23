    private static Lazy<Dictionary<string, ImageCodecInfo>> _encoders =
        new Lazy<Dictionary<string, ImageCodecInfo>>(() =>
            ImageCodecInfo.GetImageEncoders().ToDictionary(x => x.MimeType.ToLower(), x => x));
    public static Dictionary<string, ImageCodecInfo> Encoders
    {
        get { return _encoders.Value; }
    }
