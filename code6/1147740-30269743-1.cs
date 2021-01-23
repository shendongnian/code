    public static byte[] DownloadAndGetHash(Uri file, string destFilePath, int bufferSize)
    {
        using (var md5 = MD5.Create())
        using (var client = new System.Net.WebClient())
        {
            using (var src = client.OpenRead(file))
            using (var dest = File.Create(destFilePath, bufferSize))
            {
                md5.Initialize();
                var buffer = new byte[bufferSize];
                while (true)
                {
                    var read = src.Read(buffer, 0, buffer.Length);
                    if (read > 0)
                    {
                        dest.Write(buffer, 0, read);
                        md5.TransformBlock(buffer, 0, read, null, 0);
                    }
                    else // reached the end.
                    {
                        md5.TransformFinalBlock(buffer, 0, 0);
                        return md5.Hash;
                    }
                }
            }
        }
    }
