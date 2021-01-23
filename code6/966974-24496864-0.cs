    public static class Extensions
    {
        public static void Compress(this XDocument doc, string name)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(doc.ToString(SaveOptions.DisableFormatting));
            using (var ms = new MemoryStream(buffer.Length))
            {
                ms.Write(buffer,0,buffer.Length);
                ms.Seek(0, SeekOrigin.Begin);
                using (var fs = new FileStream(name, FileMode.Create))
                {
                    using (var gzipStream = new GZipStream(fs, CompressionMode.Compress))
                    {
                        ms.CopyTo(gzipStream);                        
                    }
                }
            }
        }
        public static XDocument Decompress(string name)
        {
            using (var fs = new FileStream(name,FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    using (var gzip = new GZipStream(fs,CompressionMode.Decompress))
                    {
                        gzip.CopyTo(ms);
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                    string s = Encoding.UTF8.GetString(ms.ToArray());
                    return XDocument.Parse(s);
                }
            }
        }
    }
