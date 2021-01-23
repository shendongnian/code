    public Coord(XmlReader reader)
    	{
    		if (reader == null) throw new ArgumentNullException("reader");
    
    		if (!reader.IsEmptyElement)
    		{
    			string tagName = reader.Name;
    
    			while (reader.Read() && !(reader.NodeType == XmlNodeType.EndElement && reader.Name == "coord"))
    			{
    				if (reader.NodeType == XmlNodeType.Element)
    				{
    					switch (reader.Name)
    					{
    						case "coord":
    							var x = reader.GetAttribute("x");
                                var y = reader.GetAttribute("y");
    							break;
    					}
    				}
    
    		}
    		}
    	}
    
