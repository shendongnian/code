     public static ImageCodecInfo GetEncoderInfo(string mimeType)
            {
                 string lookupKey = mimeType.ToLower(); 
                ImageCodecInfo foundCodec = null; 
                if (Encoders.ContainsKey(lookupKey))
                { 
                    foundCodec = Encoders[lookupKey];
                } 
                return foundCodec;
            }
