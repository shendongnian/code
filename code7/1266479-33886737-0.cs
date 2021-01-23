    public static string GetFormat(string xmlString)
    {
        var xml = XDocument.Parse(xmlString);
        var builder = new StringBuilder();
        BuildString(xml, builder);
        return builder.ToString();
    }
    public static void BuildString(XContainer container, StringBuilder builder)
    {
        var element = container as XElement;
        if (element != null && !element.HasElements && !string.IsNullOrEmpty(element.Value))
        {
            builder.Append(element.Value + " ");
        }
        foreach (var xElement in container.Elements())
        {
            BuildString(xElement, builder);
        }
    }
