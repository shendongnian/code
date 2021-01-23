    public static Dictionary<string, ImageCodecInfo> Encoders
    {
        get {
            return encoders ??
                   (encoders = ImageCodecInfo.GetImageEncoders().ToDictionary(c => c.MimeType.ToLower()));
        }
    }
