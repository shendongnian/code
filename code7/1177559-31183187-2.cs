    public class DelayedSingleAction
    {
    	private readonly Action _action;
    	private readonly long _millisecondsDelay;
    	private readonly AutoResetEvent _syncObject = new AutoResetEvent(true);
    	public DelayedSingleAction(Action action, long millisecondsDelay)
    	{
    		_action = action;
    		_millisecondsDelay = millisecondsDelay;
    	}
    
    	private Task _waitingTask = null;
    	private void DoActionAndClearTask(Task _)
    	{
    		_syncObject.Set();
    		_action();
    	}
    
    	public void PerformAction()
    	{
    		if (_syncObject.WaitOne(0))
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
