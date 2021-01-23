    using (var ms = new MemoryStream())
    {
        using (MemoryStream seekable = new MemoryStream())
        {
            using (var stream = response.GetResponseStream())
            {
                int bytes;
                byte[] buffer = new byte[1024];
                while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    seekable.Write(buffer, 0, bytes);
                }
            }
            seekable.Position = 0;
            using (ZipFile zipout = ZipFile.Read(seekable))
            {
                ZipEntry entry = zipout["file1.xml"];
                entry.Extract(ms);
            }
        }
        // access ms
    }
