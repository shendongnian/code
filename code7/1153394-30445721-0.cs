    WebClient webClient = new WebClient();
    string htmlCode = webClient.DownloadString("http://pastebin.com/raw.php?i=gF0DG08s");
    
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmlCode);
    
    HtmlNode OurNone = doc.DocumentNode.SelectSingleNode("//div[@id='footertext']");
    
    if (OurNone != null)
        richTextBox1.Text = OurNone.InnerHtml;
    else
        richTextBox1.Text = "nothing found";
