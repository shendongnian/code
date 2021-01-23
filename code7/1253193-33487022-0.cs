    private static bool IsSvg(string input)
    {
    	try
    	{
    		using (var file = new FileStream(input, FileMode.Open, FileAccess.Read))
    		using (var reader = new XmlTextReader(file) {XmlResolver = null})
    			return reader.Read() && reader.Name.Equals("svg", StringComparison.InvariantCultureIgnoreCase);
    	}
    	catch
    	{
    		return false;
    	}
    }
