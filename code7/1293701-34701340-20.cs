    public class WaitForDelegate : IDisposable
    {
    	private Action _detach;
    	
        public WaitForDelegate(Action<Action> add, Action<Action> remove)
        {
    		Action handler = () => Console.WriteLine("trigger");
    		_detach = () => remove(handler);
    		add(handler);
        }
    	
    	public void Dispose()
    	{
    		if (_detach != null)
    		{
    			_detach();
    			_detach = null;
    		}
    	}
    }
