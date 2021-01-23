    public static class Algorithms
    {
    	public static IEnumerable<Tuple<DateTime, TimeSpan>> IterateTimeslots(
    		this Dictionary<DayOfWeek, IEnumerable<Tuple<TimeSpan, TimeSpan>>> input,
    		DateTime startingFrom)
    	{
    		// Convert the input to ordered array of ranges containing
    		// absolute offsets from the beginning of the week
    		var ranges = input.SelectMany(e => e.Value.Select(v => new
    		{
    			Start = TimeSpan.FromDays((int)e.Key) + v.Item1,
    			End = TimeSpan.FromDays((int)e.Key) + v.Item2
    		}))
    		.OrderBy(e => e.Start)
    		.ToArray();
    		// Corner case: empty input
    		if (ranges.Length == 0) yield break;
    		// Test case #2: merge adjacent ranges
    		int last = 0;
    		for (int i = 1; i < ranges.Length; i++)
    		{
    			if (ranges[i].Start > ranges[last].End)
    				ranges[++last] = ranges[i];
    			else
    				ranges[last] = new { Start = ranges[last].Start, End = ranges[i].End };
    		}
    		bool mergeLast = ranges[last].End == TimeSpan.FromDays(7) && ranges[0].Start == TimeSpan.Zero;
    		// Test case #3: (24/7)
    		if (mergeLast && last == 0)
    		{
    			yield return Tuple.Create(startingFrom, TimeSpan.MaxValue);
    			yield break;
    		}
    		// Test case #1: Generate infinite intervals 
    		var weekStart = new DateTime(startingFrom.Year, startingFrom.Month, startingFrom.Day,
    			0, 0, 0, startingFrom.Kind).AddDays(-(int)startingFrom.DayOfWeek);
    		int index = 0;
    		while (true)
    		{
    			var start = weekStart + ranges[index].Start;
    			if (index == last && mergeLast)
    			{
    				weekStart = weekStart.AddDays(7);
    				index = 0;
    			}
    			var end = weekStart + ranges[index].End;
    			if (end > startingFrom)
    			{
    				if (start < startingFrom) start = startingFrom;
    				yield return Tuple.Create(start, end - start);
    			}
    			if (++index > last)
    			{
    				weekStart = weekStart.AddDays(7);
    				index = 0;
    			}
    		}
    	}
    }
