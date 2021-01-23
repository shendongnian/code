    // webReq.AutomaticDecompression = DecompressionMethods.None; is required for this, since we're handling that decompression ourselves.
    using (var respStream = resp.GetResponseStream())
    using (var memStream = new MemoryStream())
    {
        respStream.CopyTo(memStream);
        using (var gzip = new System.IO.Compression.GZipStream(respStream, System.IO.Compression.CompressionMode.Decompress))
        using (var reader = new StreamReader(gzip))
        {
            var content = reader.ReadToEnd();
            // you may or may not actually care about this, depending on whether this is just light testing or if you'll actually have these metrics in production
        }
        return System.Text.Encoding.UTF8.GetByteCount(responseText.ToString()) + memStream.Length;
    }
