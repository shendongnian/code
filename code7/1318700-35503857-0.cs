    public static string StripHTML(string input)
    {
       HtmlDocument doc = new HtmlDocument();
       doc.LoadHtml(input);
       return string.Join(" ", doc.DocumentNode.SelectNodes("//*[text()]").Select(node => node.InnerText));
    }
