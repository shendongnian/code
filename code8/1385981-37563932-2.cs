    var set = new HashSet<string>();
    for (int i = 0; i < strings.Length; i++)
    {
    	if (set.Contains(strings[i]))
    	{
    		strings[i] = "Duplicate";
    	}
    	else
    	{
    		set.Add(strings[i]);
    	}
    }
