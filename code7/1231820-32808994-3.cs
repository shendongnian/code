    Schedule first = null;
    bool hasOverlap = false;
    using(var enumerator = list.OrderBy(x => x.StartTime).ThenBy(x => x.EndTime).GetEnumerator())
    {
    	enumerator.MoveNext();
    	first = enumerator.Current;
    	while(enumerator.MoveNext())
    	{
    		if(enumerator.Current.StartTime < first.EndTime)
    		{
    			hasOverlap = true;
    			break;
    		}
    	}
    }
