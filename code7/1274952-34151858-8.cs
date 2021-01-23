	public static async Task SearchPnrFilesAsync(string mainDir)
	{
		foreach (string file in Directory.EnumerateFiles(mainDir, ".xml",
															SearchOption.AllDirectories))
		{
			var path = Path.Combine(@"C:\CopyFileHere", Path.GetFileName(file));
			using (var reader = File.OpenRead(file))
			using (var writer = File.OpenWrite(path))
			{
				await reader.CopyToAsync(writer);
			}	
		}	
	}
