	var element = document.Element("summary");
	var value = element.Value;
	value += string.Join(", ", document.Element("summary")
									   .Descendants()
									   .Where(x => x.NodeType == System.Xml.XmlNodeType.Element
									   .Select(x => x.ToString()));
