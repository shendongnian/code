    var setList = new List<HashSet<int>>(l.Length);
    foreach (var key in l)
    {
    	HashSet<int> set;
    	if (d.TryGetValue(key, out set) && set.Count > 0) setList.Add(set);
    }
    int commonCount = 0;
    if (setList.Count > 0)
    {
    	if (setList.Count == 1)
    		commonCount = setList[0].Count;
    	else
    	{
    		int minCountPos = 0;
    		for (int i = 1; i < setList.Count; i++)
    			if (setList[i].Count < setList[minCountPos].Count) minCountPos = i;
    		foreach (var item in setList[minCountPos])
    		{
    			bool isCommon = true;
    			for (int i = 0; i < setList.Count; i++)
    				if (i != minCountPos && !setList[i].Contains(item)) { isCommon = false; break; }
    			if (isCommon) commonCount++;
    		}
    	}
    }
    Console.WriteLine("Common elements: {0}", commonCount);
