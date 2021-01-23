    using (MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(json)))
    using (MemoryStream output = new MemoryStream())
    {
        using (GZipStream compression = new GZipStream(output, CompressionMode.Compress))
        {
            input.CopyTo(compression);
        }
        byte[] bytes = output.ToArray();
        // Use bytes
    }
