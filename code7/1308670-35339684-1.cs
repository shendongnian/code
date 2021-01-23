    public sealed class DisposableLock : IDisposable
    {
    	private readonly object _lock;
    
    	public DisposableLock(object @lock)
    	{
    		_lock = @lock;
    		Monitor.Enter(_lock);
    	}
    
    	#region Implementation of IDisposable
    
    	public void Dispose()
    	{
    		Monitor.Exit(_lock);
    	}
    
    	#endregion
    }
