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
    	
    	var accu = new List<List<Tuple<int, string>>>();
    	
    	foreach (var data in Data1)
    	{
    		if (accu.Any(t => t.Any(d => d.Item1 == (ToInt(data) - 1))))
    	    {
    			var item = accu.First(t => t.Any(d => d.Item1 == (ToInt(data) - 1)));
    			item.Add(new Tuple<int, string>(ToInt(data), data));
    		}
    		else
    		{
    			accu.Add(new List<Tuple<int, string>>{ new Tuple <int, string>(ToInt(data), data)});
    		}
    	}
    	
    	var results = new List<string>();
    
    	results.AddRange(accu.Where(g => g.Count > 2).Select(g => string.Format("{0} - {1}", g.First().Item2, g.Last().Item2)));
    	results.AddRange(accu.Where(g => g.Count <= 2).Aggregate(new List<string>(), (total, current) => { total.AddRange(current.Select(i => i.Item2)); return total; } ));
    }
    
    private static Regex digitsOnly = new Regex(@"[^\d]");
    
    public static int ToInt(string literal)
    {
    	int i;
    	int.TryParse(digitsOnly.Replace(literal, ""), out i);
    	return i;
    }
