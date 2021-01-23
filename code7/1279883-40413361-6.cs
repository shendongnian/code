    private XElement ReadElement(SyndicationFeed feed, string extspace, string extname)
    {
        var elements = feed.ElementExtensions.ReadElementExtensions<XElement>(extname, extspace);
        return elements.FirstOrDefault();
    }
    private XAttribute ReadAttribute(string extspace, string extname, string attname)
    {
        var element = ReadElement(extspace, extname);
        var attribute = element?.Attribute(attname);
        return attribute;
    }
