     public int FindClosestIndex(List<int> master, int color)
    {
    	var idx = -1;
    	var idxCloseness = int.MaxValue;
    	for (var i = 0; i < master.Count; i++)
    	{
    		var closeness = Closeness(master[i], color);
    		if (closeness < idxCloseness)
    		{
    			idx = i;
    			idxCloseness = closeness;
    		}
    	}
    	return idxCloseness;
    }
    
    public int SortColorByMasterList(List<int> master, int a, int b)
    {
    	return FindClosestIndex(master, a).CompareTo(FindClosestIndex(master, b));
    }
