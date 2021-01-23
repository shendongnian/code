    static IEnumerable<MapEntry> ParseMap(string csvFile)
    {
    	return from line in File.ReadLines(csvFile).Skip(1)
    		   let tokens = line.Split(new[] { ',' }, 4)
    		   let xmlToken = tokens[3]
    		   let xmlText = xmlToken.Substring(1, xmlToken.Length - 2)
    		   let xmlRoot = XElement.Parse(xmlText)
    		   select new MapEntry
    		   {
    			   Description = tokens[0],
    			   Name = tokens[1],
    			   Label = tokens[2],
    			   InnerCoordinates = GetCoordinates(xmlRoot.Element("innerBoundaryIs")),
    			   OuterCoordinates = GetCoordinates(xmlRoot.Element("outerBoundaryIs")),
    		   };
    }
    
    static IEnumerable<LatLng> GetCoordinates(XElement node)
    {
    	if (node == null) return Enumerable.Empty<LatLng>();
    	var element = node.Element("LinearRing").Element("coordinates");
    	return from token in element.Value.Split(' ')
    		   let values = token.Split(',')
    		   select new LatLng(XmlConvert.ToDouble(values[0]), XmlConvert.ToDouble(values[1]));
    }
