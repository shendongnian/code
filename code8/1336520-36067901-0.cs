    var url = "http://www.uefa.com/livescores/";
    var content = new System.Net.WebClient().DownloadString(url);
    var doc = new HtmlAgilityPack.HtmlDocument();
	doc.LoadHtml(content);
	var hn = doc.DocumentNode.SelectSingleNode("//table");
You can also use the HtmlWeb utility class:
    var web = new HtmlWeb();
    var doc = web.Load(url);
    var hn = doc.DocumentNode.SelectSingleNode("//table");
