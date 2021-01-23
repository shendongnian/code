        Stream stream = File.Open(filePath, FileMode.Open);
    
        var reader = XmlReader.Create(stream, XmlHelper.ReaderSettings());
    
        if (!reader.IsEmptyElement)
    			{
    				string tagName = reader.Name;
    
    				while (reader.Read() && !(reader.NodeType == XmlNodeType.EndElement))
    				{
    					if (reader.NodeType == XmlNodeType.Element)
    					{
    						switch (reader.Name)
    						{
    							case "wall_horizontal":
    								var coord = new Coord(reader);
                                    break;
    
    						}
    					}
    				}
    			}
    
