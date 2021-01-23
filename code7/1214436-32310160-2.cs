    WebClient client = new WebClient();
    var url = "http://stackoverflow.com";
    client.Headers.Add("USER", "ABC");
    string text = client.DownloadString(url);
    var csdoc = CsQuery.CQ.CreateDocument(text);
            
    foreach(var q in csdoc.Find("a.question-hyperlink"))
    {
        Debug.WriteLine(q.InnerText);
    }
