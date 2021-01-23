    public class DelayedSingleAction
    {
    	private readonly Action _action;
    	private readonly long _millisecondsDelay;
    	private readonly object _syncLock = new object ();
    	public DelayedSingleAction(Action action, long millisecondsDelay)
    	{
    		_action = action;
    		_millisecondsDelay = millisecondsDelay;
    	}
    
    	private Task _waitingTask = null;
    	private void DoActionAndClearTask(Task _)
    	{
    		lock (_syncLock)
    		{
    			_waitingTask = null;
    		}
    
    		_action();
    	}
    
    	public void PerformAction()
    	{
    		lock (_syncLock)
    		{
    			if (_waitingTask == null)
    			{
    				_waitingTask = Task.Delay(TimeSpan.FromMilliseconds(_millisecondsDelay))
                                       .ContinueWith(DoActionAndClearTask);
    			}
    		}
    	}
    
    	public Task Complete()
    	{
    		lock (_syncLock)
    		{
    			return _waitingTask ?? Task.FromResult(0);
    		}
    	}
    }
