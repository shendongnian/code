	public async Task RunAsync()
	{
		IEnumerable<string> urls = File.ReadAllLines(@"c:/temp/Input/input.txt");
	
		var urlTasks = urls.Select((url, index) =>
		{
			WebClient wc = new WebClient();
			string path = string.Format("{0}image-{1}.jpg", @"c:/temp/Output/", index);
			
			var downloadTask = wc.DownloadFileTaskAsync(new Uri(url), path);
			Output(path);
			
			return downloadTask;
		});
	
		Console.WriteLine("Start now");
		await Task.WhenAll(urlTasks);
		Console.WriteLine("Done");
	}
