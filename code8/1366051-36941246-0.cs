    HtmlNodeCollection coll = htmlDoc.DocumentNode.SelectNodes("//text()");
    
    foreach (HTMLNode node in coll)
    {
        node.InnerText = node.InnerText.Replace(...);
    }
