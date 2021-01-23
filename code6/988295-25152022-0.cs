    private void ParseXml(string xml)
    {
    	double[] low = null;
    	double[] hi = null;
    
    	using (StringReader stringReader = new StringReader(xml))
    	{
    		using (XmlReader xmlReader = XmlReader.Create(stringReader))
    		{
    			while (xmlReader.Read())
    			{
    				if (xmlReader.NodeType != XmlNodeType.Element) continue;
    
    				if (xmlReader.Name == "PointLo")
    				{
    					low = ParsePoint(xmlReader);
    				}
    				else if (xmlReader.Name == "PointHi")
    				{
    					hi = ParsePoint(xmlReader);
    				}
    			}
    		}
    	}
    }
    
    private double[] ParsePoint(XmlReader xmlReader)
    {
    	double[] point = new double[3];
    
    	using (XmlReader pointReader = xmlReader.ReadSubtree())
    	{
    		while (pointReader.Read())
    		{
    			if (pointReader.NodeType != XmlNodeType.Element) continue;
    
    			if (pointReader.Name == "x")
    			{
    				point[0] = GetDimensionValue(pointReader);
    			}
    			else if (pointReader.Name == "y")
    			{
    				point[1] = GetDimensionValue(pointReader);
    			}
    			else if (pointReader.Name == "z")
    			{
    				point[2] = GetDimensionValue(pointReader);
    			}
    		}
    	}
    
    	return point;
    }
    
    private double GetDimensionValue(XmlReader reader)
    {
    	using (XmlReader dimensionReader = reader.ReadSubtree())
    	{
    		dimensionReader.Read();
    
    		return reader.ReadElementContentAsDouble();
    	}
    }
