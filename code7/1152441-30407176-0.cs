    public static HtmlNode GetFirstByClass(this HtmlNode node, string name)
    {
        return node
            .Descendants()
            .FirstOrDefault(x => x.GetAttributeValue("class", null) == name);
    }
