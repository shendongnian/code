    public static byte[] DownloadAndGetHash(Uri file, string destFilePath, int bufferSize)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        using (var client = new System.Net.WebClient())
        {
            using (var src = client.OpenRead(file))
            using (var dest = File.Create(destFilePath, bufferSize))
            {
                var buffer = new byte[bufferSize];
                while (true)
                {
                    var read = src.Read(buffer, 0, buffer.Length);
                    if (read > 0)
                    {
                        dest.Write(buffer, 0, read);
                        md5.TransformBlock(buffer, 0, read, buffer, 0);
                    }
                    else // reached the end.
                    {
                        return md5.TransformFinalBlock(buffer, 0, 0);
                    }
                }
            }
        }
    }
