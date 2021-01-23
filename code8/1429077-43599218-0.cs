    byte[] inputBytes = ...;
	using (var compressedStream = new MemoryStream())
	{
		using (var compressor = new GZipStream(compressedStream, CompressionMode.Compress))
		{
            compressor.Write(inputBytes, 0, inputBytes.Length);
		}
		// get bytes after the gzip stream is closed 
		File.WriteAllBytes(pathToFile, compressedStream.ToArray());
	}
