	using (var wc = new System.Net.WebClient())
	{
		var html = wc.DownloadString(@"http://www.microsoft.com");
		var doc = new HtmlAgilityPack.HtmlDocument();
		doc.LoadHtml(html);
		var node = doc.DocumentNode.SelectSingleNode("/html/body/p");
		Console.WriteLine(node.InnerText);
	}
