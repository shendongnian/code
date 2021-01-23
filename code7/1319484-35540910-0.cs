    WebResponse response = webRequest.GetResponse();
    var temp = response.GetResponseStream();
    HtmlDocument Doc = new HtmlDocument();
    Doc.Load(temp);
    string innerTxt = Doc.DocumentNode.InnerText;
