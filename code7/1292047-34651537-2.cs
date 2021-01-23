    using HtmlAgilityPack;
    using Fizzler.Systems.HtmlAgilityPack;
    
    //get the page
    HtmlWeb web = new HtmlWeb();
    HtmlDocument document = web.Load("http://example.com/requested-page");
    HtmlNode page = document.DocumentNode;
    
    //loop through all images on the page
    foreach(HtmlNode item in page.QuerySelectorAll("img"))
    {
        var src = item.Attributes["src"].Value;
        // do some stuff
    }
