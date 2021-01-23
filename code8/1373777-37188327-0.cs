	private static void getPageThumbLinks()
	{
		thumbUrlsList = new List<string>();
		HtmlWeb web = new HtmlWeb();
		web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.94 Safari/537.36";
		foreach (string value in pageLinks)
		{
			HtmlDocument doc = web.Load("http://www.example.com/" + value);
			foreach (HtmlNode nodes in doc.DocumentNode.SelectNodes("//td[@class='searchResultsSmallThumbnail']/a"))
			{
				HtmlAttribute href = nodes.Attributes["href"];
				var hreflink = href.Value;
				thumbUrlsList.Add(hreflink);
				//Console.WriteLine(hreflink);
				
				// Here is where you check if the DataTable has the link
				// Table is a DataTable containing the results of your query
				var containsLink = Table.AsEnumerable().Any(row => link == row.Field<string>("link"));
				
				if (containsLink) 
				{
					// do something with it
				}
			}
		}
	}
