    List<int> testList = new List<int> {1,2,3,4,1,3,5,6,3,6,4,2,1,3,7,7,7,7,7,7,7};
    
    		var orderedGroups = testList.GroupBy(x => x)
    									.OrderByDescending(x => x.Count())
    								    .ToDictionary(x => x.Key, x => x.ToList());
    									
    		
    		var maxElements = orderedGroups.First().Value.Count;
    	
    	    
    		foreach (var x in orderedGroups.Skip(1))
    		{		
    			int yMax = maxElements - x.Value.Count;
    			
    			for (int y = 0; y < yMax; y++)
    			{
    				x.Value.Add(0); // Adding default as 0
    			}
    		}
    
    	
    	orderedGroups.Dump(); // Linqpad print call, replace with console or similar call in the visual studio
