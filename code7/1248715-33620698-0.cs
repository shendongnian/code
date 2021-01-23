    HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    try{
        var temp = new Uri(url.Url);
        var request = (HttpWebRequest)WebRequest.Create(temp);
        request.Method = "GET";
        using (var response = (HttpWebResponse)request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                htmlDoc.Load(stream, Encoding.GetEncoding("iso-8859-9"));
            }
        }
    }catch(WebException ex){
        Console.WriteLine(ex.Message);
     }
    HtmlNodeCollection c = htmlDoc.DocumentNode.SelectNodes("//a");
    
    List<string> urls = new List<string>();
    foreach(HtmlNode n in c){
        urls.Add(n.GetAttributeValue("href", ""));
    }
