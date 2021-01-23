    using (var response = (HttpWebResponse) _request.EndGetResponse(result))
    using (var stream = response.GetResponseStream())
    using (var compressedMemory = new MemoryStream())
    using (var uncompressedMemory = new MemoryStream()) // Added new memory stream
    using (var gzipStream = new GZipStream(compressedMemory, CompressionMode.Decompress))
    {
        var compressedBuffer = new byte[BlockSize];
    
        while (stream != null && stream.CanRead)
        {
            var readCount = stream.Read(compressedBuffer, 0, compressedBuffer.Length);
    
            compressedMemory.Write(compressedBuffer.Take(readCount).ToArray(), 0, readCount);
            compressedMemory.Position = 0;
    
            gzipStream.CopyTo(uncompressedMemory); // use copy to rather than trying to read
    
            var outputString = Encoding.UTF8.GetString(uncompressedMemory.ToArray());
            Debug.WriteLine(outputString);
    
            uncompressedMemory.Position = 0;
            uncompressedMemory.SetLength(0);
    
            compressedMemory.Position = 0;
            compressedMemory.SetLength(0); // reset length
        }
    }
