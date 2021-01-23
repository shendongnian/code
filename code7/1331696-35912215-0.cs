    using (var ms = new MemoryStream())
    {
        using (var zip = new DeflateStream(ms, CompressionLevel.Optimal))
        {
            using (var sw = new StreamWriter(zip))
            //using (var sw = new StreamWriter(zip, Encoding.UTF8, 4096, true))
            {
            }
            // false: zip has already been disposed
            bool canWrite = zip.CanWrite; 
        }
    }
