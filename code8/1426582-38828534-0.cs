	List<XmlNode> nodes = new List<XmlNode>();
	using (var reader = XmlReader.Create("data.xml"))
	{
		XmlDocument document = new XmlDocument();
		while (reader.Read())
		{
			if (reader.Depth == 2 && reader.NodeType == XmlNodeType.Element)
			{
				XmlNode node = document.CreateNode(XmlNodeType.Element, reader.Name, "");
                //Here I just added all the inner xml but you can do whatever you need
				node.InnerXml = reader.ReadInnerXml();
				nodes.Add(node);
			}
			reader.MoveToElement();
		}
	}
