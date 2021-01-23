	using (FileStream fs = new FileStream(downloadPath, FileMode.Open, FileAccess.Read))
	{
		byte[] buffer = new byte[2];
		fs.Read(buffer, 0, buffer.Length);
		if (buffer[0] == 0x1F
			&& buffer[1] == 0x8B)
		{
			// It's probably a GZip file
		}
		else
		{
			// It's probably not a GZip file
		}
	}
