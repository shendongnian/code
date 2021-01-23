    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
    	var hs = new HashSet<int>();
    	list.ToList().ForEach(x => hs.Add(x));
    		
    	for (int i = 0; i < hs.Count; i++)
    	{
    		var diff = sum - list[i];
    		if (hs.Contains(diff))
    		{
    			var index = list.IndexOf(diff);
    			return new Tuple<int, int>(i, index);
    		}
    	}
    		
    	return null;
    }
