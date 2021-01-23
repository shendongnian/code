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
    		int first = 0, last = first;
    		for (int i = 1; i < ranges.Length; i++)
    		{
    			if (ranges[i].Start > ranges[last].End)
    				ranges[++last] = ranges[i];
    			else
    				ranges[last] = new { Start = ranges[last].Start, End = ranges[i].End };
    		}
    		var weekLength = TimeSpan.FromDays(7);
    		if (ranges[last].End == weekLength && ranges[first].Start == TimeSpan.Zero)
    		{
    			// Test case #3: (24/7)
    			if (last == first)
    			{
    				yield return Tuple.Create(startingFrom, TimeSpan.MaxValue);
    				yield break;
    			}
    			ranges[last] = new { Start = ranges[last].Start, End = ranges[last].End + ranges[first].End };
    			first++;
    		}
    		// Test case #1: Generate infinite intervals 
    		var weekStart = new DateTime(startingFrom.Year, startingFrom.Month, startingFrom.Day,
    			0, 0, 0, startingFrom.Kind) - TimeSpan.FromDays((int)startingFrom.DayOfWeek);
    		for (int i = 0; ; i++)
    		{
    			if (i > last)
    			{
    				weekStart += weekLength;
    				i = first;
    			}
    			var start = weekStart + ranges[i].Start;
    			var end = weekStart + ranges[i].End;
    			if (end > startingFrom)
    			{
    				if (start < startingFrom) start = startingFrom;
    				yield return Tuple.Create(start, end - start);
    			}
    		}
    	}
    }
