	XmlNodeList nodes = responseDocument.GetElementsByTagName("Reason");
	for (int i = 0; i < nodes.Count; i++)
	{
		Console.WriteLine(nodes[i].InnerText);
	}
