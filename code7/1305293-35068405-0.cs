    private static object _lock = new object();
    public static Dictionary<string, ImageCodecInfo> Encoders{
        get{
           lock(_lock) {
            if (encoders == null){
                encoders = new Dictionary<string, ImageCodecInfo>();
            }
            //if there are no codecs, try loading them
            if (encoders.Count == 0){
                foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders()){
                    encoders.Add(codec.MimeType.ToLower(), codec);
                }
            }
            return encoders;
             }
        }
    }
