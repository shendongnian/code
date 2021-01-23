    // Collect the non empty matching sets, keeping the set with the min Count at position 0
    var sets = new HashSet<int>[l.Length];
    int setCount = 0;
    foreach (var key in l)
    {
    	HashSet<int> set;
    	if (!d.TryGetValue(key, out set) || set.Count == 0) continue;
    	if (setCount == 0 || sets[0].Count <= set.Count)
    		sets[setCount++] = set;
    	else
    	{
    		sets[setCount++] = sets[0];
    		sets[0] = set;
    	}
    }
    int commonCount = 0;
    if (setCount > 0)
    {
    	if (setCount == 1)
    		commonCount = sets[0].Count;
    	else
    	{
    		foreach (var item in sets[0])
    		{
    			bool isCommon = true;
    			for (int i = 1; i < setCount; i++)
    				if (!sets[i].Contains(item)) { isCommon = false; break; }
    			if (isCommon) commonCount++;
    		}
    	}
    }
    Console.WriteLine("Common elements: {0}", commonCount);
