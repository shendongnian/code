	HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com");
	request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
	request.AddRange(0, 599);
	
	using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
	using (Stream stream = response.GetResponseStream())	
	using (MemoryStream memoryStream = new MemoryStream())
	{
		stream.CopyTo(memoryStream);
		memoryStream.Seek(0, SeekOrigin.Begin);
		
		Console.WriteLine ("Stream size in bytes: {0}", memoryStream.Length);
		
		while (memoryStream.Position != memoryStream.Length)
		{
			Console.Write (Convert.ToChar(memoryStream.ReadByte()));
		}
	}
