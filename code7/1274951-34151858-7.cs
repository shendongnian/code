	public static async Task SearchPnrFilesAsync(string mainDir)
	{
		foreach (string file in Directory.EnumerateFiles(mainDir, ".xml",
															SearchOption.AllDirectories))
		{
			var path = Path.Combine(@"C:\CopyFileHere", Path.GetFileName(file));
			using (var streamReader = File.OpenRead(file))
			using (var streamWriter = new StreamWriter(path))
			{
				await streamWriter.WriteAsync(await StreamReader.ReadToEndAsync()
																.ConfigureAwait(false));
			}	
		}	
	}
