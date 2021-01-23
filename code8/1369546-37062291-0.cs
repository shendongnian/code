    internal interface IEvent { }
    internal class Watcher<T> where T : IEvent
    {
    	internal Action<T> Action;
    
    	public void On(IEvent evnt)
    	{
    		if (evnt is T) Action?.Invoke((T) evnt);
    	}
    }
