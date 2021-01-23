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
                    //Copy all attributes verbatim
                    if (reader.HasAttributes)
                       writer.WriteAttributes(reader, true);
                    //Handle empty elements by telling the writer to close right away
                    if (reader.IsEmptyElement)
                       writer.WriteEndElement();
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
                case XmlNodeType.Whitespace:
                    writer.WriteWhitespace(reader.Value);
                    break;
               //Other cases. Attributes, comments etc.
			}
			writer.Flush();
		}
	}
