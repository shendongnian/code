    StringBuilder content = new StringBuilder();
    // open the file
    using (Stream file = File.OpenRead("test.xml"))
    {
    	XmlReaderSettings settings = new XmlReaderSettings();
    	//must use this to declare the 'w' namespace
    	NameTable nt = new NameTable();
    	XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
    	nsmgr.AddNamespace("w", "urn:http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    	XmlParserContext ctx = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
    
    	using (XmlReader reader = XmlReader.Create(file, settings, ctx))
    	{
    		while (reader.Read())
    		{
    			// parse content of 't' elments and add them to the string builder
    			if (reader.NodeType == XmlNodeType.Element && reader.LocalName.Equals("t"))
    			{
    				if ("preserve".Equals(reader.GetAttribute("xml:space")))
    				{
    					reader.ReadStartElement();
    					content.Append(reader.ReadContentAsString());
    					content.AppendLine();
    				}
    				
    			}
    		}
    	}
    }
