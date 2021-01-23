	public void AppendXPath(XContainer container)
	{
		if (container == null)
			throw new ArgumentNullException("container");
	
		var doc = container as XDocument;
		if (doc != null)
			AppendXPath(doc.Root, "", 1);
		else
			AppendXPath(container as XElement, "/", 1);
	}
	
	private void AppendXPath(XElement node, string parent, int num)
	{
		var path = $"{parent}/{node.Name}[{num}]";
	
		if (node.Attribute("xpath") != null)
			throw new InvalidOperationException($"Node {path} already contains xpath attribute");
	
		var indicies = new Dictionary<XName, int>();
	
		foreach (var child in node.Elements())
		{
			int index;
			if (indicies.TryGetValue(child.Name, out index))
				indicies[child.Name] = ++index;
			else
				indicies[child.Name] = index = 1;
	
			AppendXPath(child, path, index);
		}
	
		node.Add(new XAttribute("xpath", path));
	}
