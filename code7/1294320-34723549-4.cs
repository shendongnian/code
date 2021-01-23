        string text = "<p>test <SPAN> <font> here </font> </SPAN> try</p><p><table> <tr><td><span>test</span></td></tr></table><font> try 2</font> </p>";
        StringBuilder sbtexttoCorrect = new StringBuilder();
        HtmlDocument html = new HtmlDocument();
        html.LoadHtml(text);
        var nodes = html.DocumentNode.SelectNodes("//span");
        
        foreach (var node in nodes)
        {
            node.Remove();
        }
        
        foreach (var node in html.DocumentNode.DescendantsAndSelf())
        {
            if (!node.HasChildNodes)
            {
                string t = node.InnerText;
                if (!string.IsNullOrEmpty(t))
                    sbtexttoCorrect.AppendLine(t);
            }
        }
