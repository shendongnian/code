        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml("bla<br>bla<br>bla bla<br>");
        var buffer = new StringBuilder();
        foreach (var descendant in doc.DocumentNode.Descendants())
        {
            buffer.Append(descendant.InnerHtml);
        }
        Console.WriteLine(buffer);
