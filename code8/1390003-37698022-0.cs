    // query results on page 14, to demonstrate that limit of results is avoided
    int resultPage = 130;
    string keyword = "test";
    string searchUrl = "http://www.google.com/search?q="+keyword+"&start="+resultPage;
    System.Net.WebClient webClient = new System.Net.WebClient();
    string htmlResult = webClient.DownloadString(searchUrl);
    Supremes.Nodes.Document doc = Supremes.Dcsoup.Parse(htmlResult, "http://www.google.com/");
    // parse with css selector
    foreach (Supremes.Nodes.Element result in doc.Select("h3.r a")) 
    {
        string title = result.Text;
        string url = result.Attr("href");
        // do something useful with the search result
        System.Diagnostics.Debug.WriteLine(title + " -> " + url);
    }
