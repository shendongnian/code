        System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
        System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms,
            System.IO.Compression.CompressionMode.Decompress);
        //Decompress
        int rByte = sr.Read ...
        sr.Close();
