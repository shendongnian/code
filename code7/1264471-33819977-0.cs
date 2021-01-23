    DataRow workRow; // Moved the declaration here
    while (reader.Read())
    {
    	switch (reader.NodeType)
    	{
    		case XmlNodeType.Element:
    			if (reader.Name == "Result")
    			{
    				workRow = dt.NewRow(); // this is okay if Result always comes first
    			}
    
    			if (columns.Contains(reader.Name))
    			{
    				//ERROR IS HERE out of context
    				workRow[reader.Name] = reader.Value;
    			}
    			writer.WriteStartElement(reader.Name);
    			break;
    		case XmlNodeType.Text:
    			writer.WriteString(reader.Value);
    			break;
    		case XmlNodeType.XmlDeclaration:
    		case XmlNodeType.ProcessingInstruction:
    			writer.WriteProcessingInstruction(reader.Name, reader.Value);
    			break;
    		case XmlNodeType.Comment:
    			writer.WriteComment(reader.Value);
    			break;
    		case XmlNodeType.EndElement:
    			writer.WriteFullEndElement();
    			break;
    	}
    }
