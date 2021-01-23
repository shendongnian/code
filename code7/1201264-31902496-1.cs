	public void DoRequest()
	{
		try
		{
			var address = File.ReadAllLines(@"C:\text.txt");
			var client = new WebClient();
			var result = client.DownloadString(address);
		}
		catch (Exception e)
		{
			// Do something
		}
	}
