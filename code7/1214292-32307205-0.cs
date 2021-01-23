    void Main()
    {
    	List<String> Data1 = new List<String>()
    	{
    	  "1001A",
    	  "1002A",
    	  "1003A",
    	  "1004A",
    	  "1015A",
    	  "1016A",
    	  "1007A",
    	  "1008A",
    	  "1009A",
    	};
    	
    	var accu = new List<Tuple<string, List<Tuple<int, string>>>>();
    	
    	foreach (var data in Data1)
    	{
    		if (accu.Any(t => t.Item2.Any(d => d.Item1 == (ToInt(data) - 1))))
    	    {
    			var item = accu.First(t => t.Item2.Any(d => d.Item1 == (ToInt(data) - 1)));
    			item.Item2.Add(new Tuple<int, string>(ToInt(data), data));
    		}
    		else
    		{
    			accu.Add(
    			new Tuple<string, List<Tuple<int, string>>>(
    				data, 
    				new List<Tuple<int, string>>{ new Tuple <int, string>(ToInt(data), data)})
    				);
    		}
    	}
    	
    	var results = new List<string>();
    
    	foreach (var group in accu)
    	{
    		if (group.Item2.Count > 2)
    		{
    			results.Add(string.Format("{0} - {1}", group.Item2.First().Item2, group.Item2.Last().Item2));
    		}
    		else {
    			results.AddRange(group.Item2.Select(g => g.Item2));
    		}
    	}
    	
    }
    
    private static Regex digitsOnly = new Regex(@"[^\d]");
    
    public static int ToInt(string literal)
    {
    	int i;
    	int.TryParse(digitsOnly.Replace(literal, ""), out i);
    	return i;
    }
