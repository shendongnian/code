    void Main()
    {
    	var list = new List<DateTime>();
    	list.Add(new DateTime(2014, 1, 1));
    	list.Add(new DateTime(2014, 1, 2));
    	list.Add(new DateTime(2014, 1, 3));
    	list.Add(new DateTime(2014, 1, 5));
    	list.Add(new DateTime(2014, 1, 6));
    	list.Add(new DateTime(2014, 1, 11));
    	
    	string output = string.Join("; ", GetRanges(list).Select(FormatRange));
    	Console.WriteLine(output);
        // Jan 1–3, 2014; Jan 5–6, 2014; Jan 11, 2014
    }
    
    private string FormatRange (DateRange range)
    {
    	if (range.Start.Year != range.End.Year)
    		return range.Start.ToString("MMM d, yyyy") + " – " + range.End.ToString("MMM d, yyyy");
    	else if (range.Start.Month != range.End.Month)
    		return range.Start.ToString("MMM d") + " – " + range.End.ToString("MMM d, yyyy");
    	else if (range.Start.Day != range.End.Day)
    		return range.Start.ToString("MMM d") + "–" + range.End.ToString("d, yyyy");
    	else
    		return range.Start.ToString("MMM d, yyyy");
    }
    
    private List<DateRange> GetRanges (IEnumerable<DateTime> dates)
    {
    	List<DateRange> ranges = new List<DateRange>();
    	DateRange current = null;
    	DateTime? previous = null;
    	
    	foreach (DateTime date in dates)
    	{
    		if (!previous.HasValue)
    			current = new DateRange() { Start = date };
    		else if ((date - previous.Value).Days > 1)
    		{
    			current.End = previous.Value;
    			ranges.Add(current);
    			current = new DateRange() { Start = date };
    		}	
    		previous = date;
    	}
    	
    	if (previous.HasValue)
    	{
    		current.End = previous.Value;
    		ranges.Add(current);
    	}
    	
    	return ranges;
    }
    
    public class DateRange
    {
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
    }
