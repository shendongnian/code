      public static void Save(string path, Image img, string mimeType)
            {
                using (var ms = File.OpenWrite(path))
                {
                    ImageCodecInfo encoder = GetEncoderInfo(mimeType);
                    img.Save(ms, encoder, null); 
                }
            }
