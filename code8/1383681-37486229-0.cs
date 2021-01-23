	XmlNodeList nodes = doc.GetElementsByTagName("Section");
	Dictionary<string, string> list = new Dictionary<string, string>();
	foreach (XmlNode node in nodes)
	{
		if (node.Attributes != null && node.Attributes["Name"].Value == "Input")
		{
			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Attributes != null)
					list.Add(childNode.Attributes["Name"].Value, childNode.Attributes["Datatype"].Value);
			}
		}
	}
