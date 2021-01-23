    public class Request
    {
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
    	public int PersonId { get; set; }
    	public Request(DateTime start)
    	{
    		while (!IsWorkingDay(start))
    			start = start.AddDays(1);
    		Start = start;
    		
    		End = start.AddDays(1);
    		while (!IsWorkingDay(End))
    			End = End.AddDays(1);
    	}
    	
    	private bool IsWorkingDay(DateTime date)
    	{
    		return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    	}
    	
    	public bool Intersects(Request otherRequest)
    	{
    		if (otherRequest == this)
    			return true;
    			
    		return !(otherRequest.End < Start || otherRequest.Start > End);
    	}
    	
    	public void Merge(Request otherRequest)
    	{
    		if (otherRequest.Start < Start)
    			Start = otherRequest.Start;
    		if (otherRequest.End > End)
    			End = otherRequest.End;
    	}
    }
