	static void Main(string[] args)
	{
		DoItAsync().Wait(); 
	}
	
	static async Task DoItAsync()
	{
		System.Net.WebClient wc = new System.Net.WebClient();
		var task1 = wc.DownloadStringTaskAsync("https://www.google.com.au");
		Console.WriteLine(await task1);
		Console.WriteLine("done!"); // this never gets printed
	}
	
