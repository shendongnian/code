    using (var parser = new TextFieldParser(path))
    {
    	parser.SetDelimiters(",");
    	while (!parser.EndOfData)
    	{
    		string[] results = parser.ReadFields();
    		if (results[0].StartsWith(">>"))
    		{
    			// headers
    		}
    		else
    		{
    			// data
    		}
    	}
    }
