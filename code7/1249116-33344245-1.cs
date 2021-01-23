    public bool IsMerge(string target, string part1, string part2)
    {
    	if (String.IsNullOrEmpty(target))
    	{
    		throw new ArgumentNullException("target");
    	}
    
    	if (String.IsNullOrEmpty(part1))
    	{
    		throw new ArgumentNullException("part1");
    	}
    
    	if (String.IsNullOrEmpty(part2))
    	{
    		throw new ArgumentNullException("part2");
    	}
    
    	if (target.Length == (part1.Length + part2.Length))
    	{
    		return this.IsPart(target, part1) && this.IsPart(target, part2);
    	}
    
    	return false;
    }
    
    private bool IsPart(string target, string part)
    {
    	int idx = -1;
    	int lastIdx = 0;
    
    	for (int i = 0; i < part.Length; i++)
    	{
    		idx = (target.IndexOf(part[i], lastIdx));
    		if (!(idx > -1))
    		{
    			return false;
    		}
    
    		lastIdx = idx;
    	}
    
    	return true;
    }
