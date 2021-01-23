    string myString;
    byte[] filecontent = Convert.FromBase64String(strcontent);
	using (var filestream = new MemoryStream(filecontent))
	{
		using (ZipFile zip = ZipFile.Read(filestream))
		{
			foreach (ZipEntry entry in zip.Entries)
			{
				if ((entry.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase)) ||
					(entry.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)))
				{
					using (var ms = new MemoryStream())
					{
						entry.ExtractWithPassword(ms, "password");
						
						ms.Position = 0;
						var sr = new StreamReader(ms);
						myString = sr.ReadToEnd();
					}
					...
