    static string[][] Solve(string[] input)
    {
    	List<string> myList = new List<string>(input);
    	List<string[]> groups = new List<string[]>();
    	while (myList.Count > 0)
    	{
    		string currentStr = myList[0];
    		int currentNum = int.Parse(currentStr.Substring(1));
    		List<string> lessThan4 = new List<string>();
    		lessThan4.Add(currentStr);
    		for (int i = 1; i < myList.Count; i++)
    		{
    			if (Math.Abs(currentNum - int.Parse(myList[i].Substring(1))) < 4)
    			{
    				// Add it to the list only if there's not the same letter in there
    				if (!lessThan4.Where(a => a.Contains(myList[i].Substring(0, 1))).Any())
    				{
    					lessThan4.Add(myList[i]);
    				}
    			}
    		}
    		lessThan4.Sort();
    		groups.Add(lessThan4.ToArray());
    		myList = myList.Except(lessThan4).ToList();
    	}
    	return groups.ToArray();
    }
