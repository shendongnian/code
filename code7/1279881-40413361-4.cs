    private XElement ReadElement(SyndicationFeed feed, string extspace, string extname)
    {
        var elements = feed.ElementExtensions.ReadElementExtensions<XElement>(extname, extspace);
        return elements.FirstOrDefault();
    }
    private string ReadAttribute(SyndicationFeed feed, string extspace, string extname, string attname)
    {
        var element = ReadElement(feed, extspace, extname);
        var attribute = element?.Attribute(attname);
        return attribute?.Value;
    }
