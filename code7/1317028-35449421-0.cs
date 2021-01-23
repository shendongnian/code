    HtmlDocument document = new HtmlDocument();
	document.LoadHtml(html);
    var link = document.DocumentNode.SelectSingleNode("//a");
    if (link != null)
    {
        if(link.InnerText.Contains("ticket"))
        {
            Console.WriteLine(link.InnerText);
        }
    }
