    public void CopyTo(XmlReader reader, XmlWriter writer, 
        Dictionary<string, string> replacements)
	{
		var currentElementName = "";
		while (reader.Read())
		{
			switch (reader.NodeType)
			{
				case XmlNodeType.Element:
					currentElementName = reader.Name;
					writer.WriteStartElement(reader.Name);
					break;
				case XmlNodeType.EndElement:
					currentElementName = "";
					writer.WriteEndElement();
					break;
				case XmlNodeType.Text:
					if (replacements.ContainsKey(currentElementName))
						writer.WriteString(replacements[currentElementName]);
					else
						writer.WriteString(reader.Value);
					break;
               //Other cases. Attributes, comments etc.
			}
			writer.Flush();
		}
	}
