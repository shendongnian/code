    var reader = new StreamReader(File.OpenRead(@"data.csv"));
    var dic = new Dictionary<int, string>();
    
    while (!reader.EndOfStream)
    {
    	var line = reader.ReadLine();
    	var values = line.Split(',');
    
    	if (!String.IsNullOrEmpty(values[0]))
    	{
    		var id = Convert.ToInt32(values[0]);
    
    		if (!String.IsNullOrEmpty(values[4]))
    		{
    			dic.Add(id, values[4]);
    		}
    	}
    }
