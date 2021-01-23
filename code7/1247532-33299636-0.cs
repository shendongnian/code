	System.Net.WebClient wc = new System.Net.WebClient();
	wc.DownloadStringCompleted += (s, u) =>
	{
		DownloadStringCompleted(s, u);
	};
	wc.DownloadStringAsync(new Uri("http://www.sofascore.com/football/livescore/json"));
	private void DownloadStringCompleted(object s, DownloadStringCompletedEventArgs u)
	{
		try
		{
			var Item = JsonConvert.DeserializeObject<RootObject>(u.Result.ToString());
		}
		catch (Exception ex)
		{ }
	}	
