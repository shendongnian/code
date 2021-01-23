	using (FileStream fstream = new FileStream(@"C:\path\to\file.bin", FileMode.Open))
	{
		while (fstream.CanRead)
		{
			byte[] buffer = new byte[5 * 1024 * 1024]; // 5MB in bytes is 5 * 2^20
			int bytesRead = fstream.Read(buffer, 0, buffer.Length);
			if (bytesRead > 0)
			{
				// do your processing
			}
		}
	}
