	public async Task FooAsync()
	{
		string pageHtml = await GrabPageHtmlAsync(pageUrl);
		Console.WriteLine(pageHtml);
	}
	
