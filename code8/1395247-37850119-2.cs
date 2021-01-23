    public class foo
    {
    	private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    	DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
    	string _name;
    	DateTime _startDate;
    
    	public foo()
    	{
    	}
    
    	public String Name {
    		get { return _name; }
    		set { _name = value; }
    	}
    	
    	public Double dueInDays 
    	{ 
    		get { return (indianTime - _startDate).TotalDays; }
    	}
    	
    	public DateTime StartDate
    	{
    		get { return _startDate; }
    		set { _startDate = value; }
    	}
    }
