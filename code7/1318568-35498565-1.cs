    var input = new string[]
    	{
    		"welcome guys",
    		"guys and", 
    		"and ladies",
    		"ladies repeat",
    		"repeat welcome",
    		"welcome guys"
    	};
    	
    var groups =
    	input
    	.GroupBy(x => x);
    
    foreach (var g in groups)
    {
    	Console.WriteLine("{0}, {1}", g.Key, g.Count().ToString());
    }
