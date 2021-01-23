    static void Main(string[] args)
    {
      using (var fileStream = File.OpenRead(@"freebase-rdf-latest.gz"))
      {
        long[] gzipLengths = ReadGzipLengths(fileStream);
        long gzipOffset = 0;
        var buffer = new byte[1048576];
        long total = 0;
        foreach (long gzipLength in gzipLengths)
        {
          fileStream.Position = gzipOffset;
          using (var gz = new GZipStream(fileStream, CompressionMode.Decompress, true)) // true <- don't close FileStream at Dispose()
          {
            int read;
            while ((read = gz.Read(buffer, 0, buffer.Length)) > 0) total += read;
          }
          gzipOffset += gzipLength;
          Console.WriteLine("Uncompressed Bytes: {0:N0} ({1:N2} %)", total, gzipOffset * 100.0 / fileStream.Length);
        }
      }
    }
