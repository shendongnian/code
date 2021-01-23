    public string ReplacePElement(string htmlContent) 
    {
      HtmlDocument doc = new HtmlDocument();
      doc.LoadHtml(htmlContent);
    
      foreach(HtmlNode p in doc.DocumentNode.SelectNodes("p"))
      {
        string value = tb.InnerText.Length>0 ? tb.InnerText : "&nbsp;";
        HtmlNode lbl = doc.CreateElement("span");
        lbl.InnerHtml = value;
    
        tb.ParentNode.ReplaceChild(lbl, tb);
      }
    
      return doc.DocumentNode.OuterHtml;
    }
