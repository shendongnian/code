    using System.Linq; //at top of file
    private static string[][] TransformInput(string[] input)
    {
        var sortOrder = new[] { "Serial", "Width", "Height", "Active1", "Active2", "Time" };
    
    	//dictionary pointing words to position in input
    	var inputDict = Enumerable.Range(0, input.Length/3)
    	    	.Select(i => i*3).ToDictionary(i => input[i]);
    	//Try to read position from dictionary; return nulls if fail
    	return sortOrder.Select(x => {
    			int i;
    			return (inputDict.TryGetValue(x, out i))
    				? new[]{x, input[i+1], input[i+2]}
    				: new[]{x, null, null};
    		}).ToArray();
    }
