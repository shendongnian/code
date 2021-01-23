    public static IEnumerable<string> JoinEverySecond(this IList<string> list)
    {
    	if (list == null)
    	{
    		throw new ArgumentNullException("list");
    	}
    
    
    	for (var i = 0; i < list.Count; i += 2)
    	{
    		if (i + 1 >= list.Count)
    		{
    			yield return list[i];
    		}
    
    		yield return string.Join(",", list[i], list[i + 1]);
    	}
    }
