    using (var ms = new MemoryStream())
    {
        using (var gz = new GZipStream(ms, CompressionMode.Compress, leaveOpen: true))
        {
           // ... write to gz
        }
        Console.WriteLine(ms.Length);  // this is the final and accurate length
    }
