    List<Tuple<string,double>> items = new List<Tuple<string,double>>() 
    { 
    	new Tuple<string,double>("q", .5),  
    	new Tuple<string,double>("w", 1.5), 
    	new Tuple<string,double>("e", .7), 
    	new Tuple<string,double>("r", .8), 
    	new Tuple<string,double>("q", .5)
    };
    
    
    var sumvalue = items.Sum(c=>c.Item2); // Calculates sum of all values
    
    var betweensum = items.SkipWhile(x=>x.Item1 == "q") // Skip until matching item1			
    	.TakeWhile(x=>x.Item1 != "q") // take until matching item1
    	.Sum(x=>x.Item2); // Sum
