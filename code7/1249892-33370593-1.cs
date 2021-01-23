    public class MyClass
    {
        public DateTime Created { get; set; }
	    public DateTime LastChanged { get; set; }
	    public DateTime LastAccessed { get; set; }
    	public bool WasCreatedInTimespan(DateTime? begin, DateTime? end)
	    {
		    return IsDateInTimespan(Created, begin, end);
    	}
    	public bool WasChangedInTimespan(DateTime? begin, DateTime? end)
    	{
    		return IsDateInTimespan(LastChanged, begin, end);
    	}
    	public bool WasAccessedInTimespan(DateTime? begin, DateTime? end)
    	{
    		return IsDateInTimespan(LastAccessed, begin, end);
    	}
    	private static bool IsDateInTimespan(DateTime date, DateTime? begin, DateTime? end)
    	{
    		return (!begin.HasValue || date >= begin.Value) && (!end.HasValue || date >= end.Value);
    	}
    }
