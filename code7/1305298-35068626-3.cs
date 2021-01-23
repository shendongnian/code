    private static Lazy<ReadOnlyDictionary<string, ImageCodecInfo>> _encoders =
        new Lazy<ReadOnlyDictionary<string, ImageCodecInfo>>(() =>
            new ReadOnlyDictionary<string, ImageCodecInfo>(
                ImageCodecInfo.GetImageEncoders()
                    .ToDictionary(x => x.MimeType.ToLower(), x => x)));
    public static IReadOnlyDictionary<string, ImageCodecInfo> Encoders
    {
        get { return _encoders.Value; }
    }
