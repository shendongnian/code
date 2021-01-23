    var output = new MemoryStream();
    using (var stream = new MemoryStream(bufferIn))
    {
        using (var decompress = new DeflateStream(stream, CompressionMode.Decompress))
        {
            decompress.CopyTo(output);;
        }
    }
    output.Position = 0;
    var unCompressedArray = output.ToArray();
    output.Close();
    output.Dispose();
    return Encoding.UTF8.GetString(unCompressedArray);
