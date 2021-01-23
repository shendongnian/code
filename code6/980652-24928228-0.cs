        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
        //Compress
        sw.Write ...
        sw.Close();
