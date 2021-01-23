    var document = new XmlDocument();
    document.LoadXml(xmlString);
    
	Dictionary<string, bool> used = new Dictionary<string, bool>();
	var allNodes = document.SelectNodes("Root/Main");
	for (int i = allNodes.Count - 1; i >= 0; i--)
	{
		var name = ((XmlElement)allNodes[i]).GetAttribute("Name");
		if (used.ContainsKey(name))
		{
			allNodes[i].ParentNode.RemoveChild(allNodes[i]);
		}
		else
		{
			used.Add(name, true);
		}
	}
	Console.WriteLine(document.OuterXml);
