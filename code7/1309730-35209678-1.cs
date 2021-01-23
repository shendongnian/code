    public class Owner : IDisposable
    {
    	private SocketWrapper _wrapper;
    	public ISocketWrapper SocketAccess { get { return _wrapper; } }
    	public void Dispose()
    	{
    		if (_wrapper != null)
    			_wrapper.Dispose();
    	}
    }
    
    public interface ISocketWrapper
    {
    	// exposed properties/methods
    }
    
    
    internal class SocketWrapper : ISocketWrapper, IDisposable
    {
    	public void Dispose()
    	{
    		// dispose socket
    	}
    }
