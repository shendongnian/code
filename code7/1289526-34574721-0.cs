    using (var fsout = File.Create(fileOut))
    {
        using (var fsIn = File.OpenRead(fileIn))
        {
            using (var zip = new GZipStream(fsIn, CompressionMode.Decompress))
            {
                var buffer = new byte[1024 * 32];
                int bytesRead;
           
                while ((bytesRead = zip.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsout.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
