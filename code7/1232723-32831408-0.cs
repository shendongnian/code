    IEnumerable<IEnumerable<Slot>> ToGroups(IEnumerable<Slot> slots)
    {
    	using (var ie = slots.GetEnumerator())
    	{
    		var range = new List<Slot>();
    		while (ie.MoveNext())
    		{
    			if (range.Count > 0)
    			{
    				if (ie.Current.Start > range[range.Count - 1].End)
    				{
    					yield return range;
    					range = new List<Slot>{ie.Current};
    					continue;
    				}
    			}
    			range.Add(ie.Current);
    		}
    		yield return range;
    	}
    }
