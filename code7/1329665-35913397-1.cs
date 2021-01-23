      private static Dictionary<string, ImageCodecInfo> _encoders;
    
            /// <summary>
            ///     A quick lookup for getting image encoders
            /// </summary>
            private static Dictionary<string, ImageCodecInfo> Encoders
            {
                get
                {
                    if (_encoders == null)
                    {
                        _encoders = new Dictionary<string, ImageCodecInfo>();
                    }
                    if (_encoders.Count == 0)
                    {
                        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                        {
                            _encoders.Add(codec.MimeType.ToLower(), codec);
                        }
                    }
                    return _encoders;
                }
            }
