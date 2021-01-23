    public string GetInnerHtml(string html)
    {
          HtmlDocument doc = new HtmlDocument();
          doc.LoadHtml(html);
          var nodes = doc.DocumentNode.SelectNodes("//div[@class=\"panel-body\"]");
          StringBuilder sb = new StringBuilder();
          foreach (var n in nodes)
          {
                sb.Append(n.InnerHtml);
          }
          return sb.ToString();
    }
