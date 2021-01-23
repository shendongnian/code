    public class DelayedSingleAction
    {
    	private readonly Action _action;
    	private readonly long _millisecondsDelay;
    	private long _syncValue = 1;
    	public DelayedSingleAction(Action action, long millisecondsDelay)
    	{
    		_action = action;
    		_millisecondsDelay = millisecondsDelay;
    	}
    
    	private Task _waitingTask = null;
    	private void DoActionAndClearTask(Task _)
    	{
    		Interlocked.Exchange(ref _syncValue, 1);
    		_action();
    	}
    
    	public void PerformAction()
    	{
    		if (Interlocked.Exchange(ref _syncValue, 0) == 1)
    		{
    			_waitingTask = Task.Delay(TimeSpan.FromMilliseconds(_millisecondsDelay))
                                   .ContinueWith(DoActionAndClearTask);
    		}
    	}
    
    	public Task Complete()
    	{
    		return _waitingTask ?? Task.FromResult(0);
    	}
    }
