    Task.Factory.StartNew(async () =>
    {
    	using (HttpClient client = new HttpClient())
    	{
    		await client.PostAsync("http://localhost/api/action", new StringContent(""));
    	}
    });
