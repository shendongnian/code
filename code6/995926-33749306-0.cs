        using (Stream s = File.OpenRead("file.gz"))
        {
            uint timestamp = 0;
            for (int x = 0; x < 4; x++)
                s.ReadByte();
            for (int x = 0; x < 4; x++)
            {
                timestamp += (uint)s.ReadByte() << (8*x);
            }
            DateTime innerFileTime = new DateTime(1970, 1, 1).AddSeconds(timestamp)
                // Gzip times are stored in universal time, I actually needed two calls to get it almost right, and the time was still out by an hour
                .ToLocalTime().ToLocalTime();
                
            // Reset stream position before decompressing file
            s.Seek(0, SeekOrigin.Begin);
        }
