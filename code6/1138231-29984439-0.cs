    public static void Main()
    {
        var doc = new XmlDocument();
        var content = doc.CreateElement("content");
        doc.AppendChild(content);
        var item = CreateItem(doc, "the hint", "the type", "the title", "the value");
        content.AppendChild(item);
    }
    
    public static XmlElement CreateItem(XmlDocument doc, string hint, string type, string title, string value)
    {
        var item = doc.CreateElement("item");
        item.SetAttribute("Hint", hint);
        item.SetAttribute("Type", type);
        AppendTextElement(item, "Title", title);
        AppendTextElement(item, "Value", value);
        return item;
    }
    
    public static XmlElement AppendTextElement(XmlElement parent, string name, string value)
    {
        var elem = parent.OwnerDocument.CreateElement(name);
        parent.AppendChild(elem);
        elem.InnerText = value;
        return elem;
    }
