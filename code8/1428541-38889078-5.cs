	private static void AddTypeDefinition(XmlDocument document)
    {
		const string xsiNamespaceUri = "http://www.w3.org/2001/XMLSchema-instance";
		XmlNode node = document.SelectSingleNode("root");
		if (node == null) return;
		string type = "DerivedOneClass";
		
		XmlNodeList nodes = node.SelectNodes("//elementThree");
		if(nodes != null && nodes.Count > 0)
			type = "DerivedTwoClass";
		
		var typeAttribute = node.Attributes["type", xsiNamespaceUri];
		if (typeAttribute != null) continue;
		XmlAttribute attribute = document.CreateAttribute("xsi", "type", xsiNamespaceUri);
		attribute.Value = type;
		node.Attributes.Append(attribute);
	}
