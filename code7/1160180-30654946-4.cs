    public List<int> GetDuplicateKeys(Dictionary<int, List<string>> dictionary)
    {
    	return dictionary
            .OrderBy (x => x.Key)
            .GroupBy(x => x.Value, new StringListComparer())
    		.Where (x => x.Count () > 1)
            .Aggregate (
    			new List<int>(),
    			(destination, dict) => 
    				{
    					var first = dict.FirstOrDefault();
    					
    					foreach (var kvp in dict)
    					{
    						if (!kvp.Equals(first))
    							destination.Add(kvp.Key);
    					}
    					
    					return destination;
    				}	
    		).ToList();
    }
