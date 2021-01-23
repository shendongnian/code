    public class GameState
    {
    	private readonly TimeOutTime _timeOutTime;
    
    	public GameState(TimeOutTime timeOutTime)
    	{
    		_timeOutTime = timeOutTime;
    	}
    
    	public TimeOutTime TimeOutTime { get { return _timeOutTime; } }
    }
    
    public class TimeOutTime
    {
    	private readonly DateTime _dateTime;
    
    	public TimeOutTime(DateTime dateTime)
    	{
    		_dateTime = dateTime;
    	}
    
    	public static implicit operator DateTime(TimeOutTime timeOutTime)
    	{
    		return new TimeOutTime(timeOutTime);
    	}
    
    	public static implicit operator TimeOutTime(DateTime timeOutTime)
    	{
    		return new TimeOutTime(timeOutTime);
    	}
    }
