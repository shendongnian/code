	public string GetID(string path)
	{
		XmlReader reader = XmlReader.Create(path);
		while (reader.Read())
		{
			if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "link"))
			{
			if (reader.HasAttributes)
			{
				var id = reader.GetAttribute("href");
				if (id.Contains(@"&vId"))
				{
					MessageBox.Show(id + "= correct id");
					return id;
				}
			}
		}
		return String.Empty;
	}
