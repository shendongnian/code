    public static ItemList Load(Stream stream)
    {
        XmlDocument document = new XmlDocument();
        document.Load(stream);
        ModifyTypes(document);
        XmlReader reader = new XmlNodeReader(document);
        XmlSerializer serializer = new XmlSerializer(typeof(ItemList));
        return serializer.Deserialize(reader) as ItemList;
    }
    public static ModifyTypes(XmlDocument document)
    {
        const string xsiNamespaceUri = "http://www.w3.org/2001/XMLSchema-instance";
		XmlNodeList nodes = originalDocument.SelectNodes("//Item");
		if (nodes == null) return;
		foreach (XmlNode item in nodes)
		{
			if (item == null) continue;
			if (item.Attributes == null) continue;
			var typeAttribute = item.Attributes["type", xsiNamespaceUri];
			if (typeAttribute != null) continue;
            // here you'll have to add some logic to get the actual 
            // type name based on your structure
			XmlAttribute attribute = document.CreateAttribute("xsi", "type", xsiNamespaceUri);
			attribute.Value = "Car";
			signDefinition.Attributes.Append(attribute);
		}
    }
