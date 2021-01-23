    public class DateEntryComparer : IEqualityComparer<DateEntry>
    {	
    	public bool Equals(DateEntry lhs, DateEntry rhs)
    	{
    		return lhs.Day == rhs.Day && lhs.Month == rhs.Month;
    	}
    	
    	public int GetHashCode(DateEntry entry)
    	{
    		return entry.Day.GetHashCode() ^ entry.Month.GetHashCode();
    	}
    }
    
    public class DateEntry : IComparable<DateEntry>
    {
    	public int Day {get;set;}
    	public int Month {get;set;}	
    	
    	public int CompareTo(DateEntry entry)
    	{
    		var result = Month.CompareTo(entry.Month);
    		
    		if(result == 0)
    		{
    			result = Day.CompareTo(entry.Day);
    		}
    		
    		return result;
    	}
    }
    
    public class Calendar
    {
        public List<int> Months { get; set; }
        public List<int> Days { get; set; }
        public int Year { get; set; }
    
        public Calendar(int year)
        {
            Months = new List<int>();       
            Days = new List<int>();
            Year = year;
        } 
    	
    	public IEnumerable<DateEntry> GetDateEntries()
    	{
    		return from d in Days 
    			   from m in Months
    			   select new DateEntry { Day = d, Month = m };
    	}
    }
