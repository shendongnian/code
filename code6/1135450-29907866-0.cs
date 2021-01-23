	/// <summary>
	///		Zip a file stream
	/// </summary>
	/// <param name="originalFileStream"> MemoryStream with original file </param>
	/// <param name="fileName"> Name of the file in the ZIP container </param>
	/// <returns> Return byte array of zipped file </returns>
	private byte[] GetZippedFiles(MemoryStream originalFileStream, string fileName)
	{
		using (MemoryStream zipStream = new MemoryStream())
		{
			using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
			{
				var zipEntry = zip.CreateEntry(fileName);
				using (var writer = new StreamWriter(zipEntry.Open()))
				{
					originalFileStream.WriteTo(writer.BaseStream);
				}
				return zipStream.ToArray();
			}
		}
	}
	/// <summary>
	///		Download zipped file
	/// </summary>
	[HttpGet]
	public FileContentResult Download()
	{
		var zippedFile = GetZippedFiles(/* your stream of original file */, "hello");
		return File(zippedFile,	// We could use just Stream, but the compiler gets a warning: "ObjectDisposedException: Cannot access a closed Stream" then.
					"application/zip",
					"sample.zip");
	}
