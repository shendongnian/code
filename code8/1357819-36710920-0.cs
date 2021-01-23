    var i = 0;
    var j = 0;
    
    while(i < oldList.Count || j < newList.Count)
    {
    	if (i >= oldList.Count)
    	{
    		for(; j < newList.Count; j++)
    		{
    			Console.WriteLine("{0} added", newList[j]);
    		}
    		break;
    	}
    	if (j >= newList.Count)
    	{
    		for(; i < oldList.Count; i++)
    		{
    			Console.WriteLine("{0} removed", oldList[i]);
    		}
    		break;
    	}
    
    	if (oldList[i] == newList[j])
    	{
    		Console.WriteLine("{0} not changed", oldList[i]);
    		i++;
    		j++;
    	}
    	else if(j < (newList.Count - 1) && oldList[i] == newList[j+1])
    	{
    		Console.WriteLine("{0} added", newList[j]);
    		j++;
    	}
    	else
    	{
    		Console.WriteLine("{0} removed", oldList[i]);
    	    i++;
    		
    	}
    }
