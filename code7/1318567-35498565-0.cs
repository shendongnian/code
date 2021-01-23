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
    
    foreach (var group in groups)
    {
    	Console.WriteLine("{0}, {1}", group.Key, group.Count().ToString());
    }
