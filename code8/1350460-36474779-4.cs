    static void Main(string[] args)
    {
        var data = GetData();
    
        int hour = 16;
        int totalCurveCount = 2;
        
        var grouping = data
               .Where(x => x.Timestamp.Hour >= hour && x.Timestamp.Hour < (hour + 1))
               .GroupBy(x => x.Timestamp)
               .Where(x => x.Count() == totalCurveCount); //there is no need to select curveId like in your code: Where(x => x.Select(y => y.curveID).Count() == nrcurves);
        
        var grouping2 = grouping
               .GroupBy(x => x.Key.Date)
               .Select(x =>
    		        new CurveGroup
                    {
    		           Timestamp = x.Key,
    		           Curves = x.OrderBy(c => c.Key).Take(totalCurveCount).SelectMany(c => c)
    		        }
               );
    
    
        foreach (var g in grouping2)
        {
    	    foreach (var c in g.Curves)
    	    {
    	        Console.WriteLine(c.Timestamp);
    	        Console.WriteLine(c.CurveID);
    	    }
        }
    }
