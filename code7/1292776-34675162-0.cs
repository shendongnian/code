    struct TimeRange
    {
    	DateTime Start;
    	DateTime End;
    	
    	public TimeRange(DateTime start, DateTime end)
    	{
    		Start = start;
    		End = end;
    	}
    	
    	public TimeSpan Duration
    	{
    		get
    		{
    			return End-Start;
    		}
    	}
    	
    	public static bool Overlap(TimeRange tr1, TimeRange tr2)
    	{
    		return (tr2.Start <= tr1.End && tr1.Start <= tr2.End);
    	}
    	
    	public static TimeRange Merge(TimeRange tr1, TimeRange tr2)
    	{
    		return new TimeSpan(
    			(tr1.Start < tr2.Start) ? tr1.Start : tr2.Start,
    			(tr1.End > tr2.End) ? tr1.End : tr2.End
    		);
    	}
    }
    List<TimeRange> timeRanges; // A copy of your data list
    
    for(int i = 0; i < timeRanges.Count; i++)
    {
    	for(int j = i+1; j < timeRanges.Count; j++)
    	{
    		if(TimeRange.Overlap(timeRanges[i],timeRanges[j])
    		{
    			timeRanges[i] = TimeRange.Merge(timeRanges[i],timeRanges[j]);
    			timeRanges.RemoveAt(j);
    			j--;
    		}
    	}
    }
    
    TimeSpan totalDuration = TimeSpan.Zero;
    foreach(TimeRange in timeRanges)
    {
    	totalDuration += timeRanges.Duration;
    }
