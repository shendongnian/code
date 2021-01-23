    void ReadAndSortInArrays(string fileLocation)
    {
    	List<string> noData = new List<string>();
    	List<string> Data = new List<string>();
    
    	using(StreamReader sr = new StreamReader(fileLocation))
    	{
    		string line;
    		
    		while(!sr.EndOfStream)
    		{
    			line = sr.ReadLine();
    			
    			if(line.StartsWith("@relation") && line.Contains("@attribute"))
    			{
    				noData.Add(line);
    			}
    			else if(line.StartsWith("@data")
    			{
    				Data.Add(line);
    			}
    			else
    			{
    				// This is stange
    			}
    		}
    	}
    	
    	var noDataArray = noData.ToArray();
    	var DataArray = Data.ToArray();
    }
