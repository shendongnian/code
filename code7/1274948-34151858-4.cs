	public async static Task SearchPnrFilesAsync(string mainDir)
	{
		foreach (string file in Directory.EnumerateFiles(mainDir, ".xml",
															SearchOption.AllDirectories))
		{
			var sb = new StringBuilder();
			using (FileStream sourceStream = new FileStream(file,
			FileMode.Open, FileAccess.Read, FileShare.Read,
			bufferSize: 4096, useAsync: true))
			{
				byte[] buffer = new byte[0x1000];
				int numRead;
				while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
				{
					
					string text = Encoding.Unicode.GetString(buffer, 0, numRead);
					sb.Append(text);
				}
			}
			var path = Path.Combine(@"C:\CopyFileHere", Path.GetFileName(file));
			using (StreamWriter sw = new StreamWriter(path))
			{
				await sw.WriteAsync(sb.ToString());
			}	
		}	
	}
