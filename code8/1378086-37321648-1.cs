    var x = XElement.Parse(xml).Elements("DIMENSION");
    List<int> sums = new List<int>();
    
    foreach (var item in x)
    {
    	try
    	{
    		sums.Add(item.Elements("STATUS").Elements("percentage").Sum(e => int.Parse(e.Value)));
    	}
    	catch(Exception e)
    	{
    
    	}
    }
