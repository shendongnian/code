    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='142248']//b");
    foreach (HtmlNode n in nodes)
    {
        if (n.InnerText.ToLower().Contains("label"))
        {
             Console.WriteLine(n.InnerText);
        }
    }
