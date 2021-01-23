	private async Task<float> ParseWebsiteAsync(Uri url)
	{
		await LoadPageAsync(url);
	
		var priceNode = document.DocumentNode.SelectSingleNode
			(@"//*[@id='pageWrapper']/div[4]/section[1]/div[4]/div[1]/div[1]/span");
		var price = priceNode.InnerText;
		return priceInFloat;
	}
	
	private async Task LoadPageAsync(Uri url)
	{
		HttpClient http = new HttpClient();
		var source = await http.GetAsStringAsync(url);
		
		source = WebUtility.HtmlDecode(source);
		document.LoadHtml(source);
	}
	
