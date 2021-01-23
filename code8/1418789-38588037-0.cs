	public void Append(XDocument doc)
	{
		Append(doc.Root, "", 1);
	}
	
	public void Append(XElement node, string parent, int num)
	{
		var path = parent + "/" + node.Name + "[" + num + "]";
	
		if (node.Attribute("xpath") != null)
			throw new InvalidOperationException("Node " + path + " already contains xpath attribute");
	
		var indicies = new Dictionary<XName, int>();
	
		foreach (var child in node.Elements())
		{
			int index;
			if (indicies.TryGetValue(child.Name, out index))
				indicies[child.Name] = ++index;
			else
				indicies[child.Name] = index = 1;
	
			Append(child, path, index);
		}
	
		node.Add(new XAttribute("xpath", path));
	}
