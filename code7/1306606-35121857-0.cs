	var document = new HtmlAgilityPack.HtmlDocument();
	document.LoadHtml(html);
	
	string[] lines =
		document
			.DocumentNode
			.Descendants("li")
			.Select(x => System.Net.WebUtility.HtmlDecode(x.InnerText))
			.ToArray();
			
	string text = String.Join(Environment.NewLine, lines);
