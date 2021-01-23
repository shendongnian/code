    class DelayedJob
    {
    	private readonly TimeSpan _delay;
    	private readonly Action _action;
    	private readonly DateTime _start;
    
    	public DelayedJob(TimeSpan delay, Action action)
    	{
    		if (action == null)
    		{
    			throw new ArgumentNullException("action");
    		}
    		_delay = delay;
    		_action = action;
    		_start = DateTime.Now;
    	}
    
    	/// <summary>
    	/// Updates this instance.
    	/// </summary>
    	/// <returns>true if there is more work to do, false otherwise</returns>
    	public bool Update()
    	{
    		if (DateTime.Now - _start >= _delay)
    		{
    			_action();
    			return false;
    		}
    
    		return true;
    	}
    }
