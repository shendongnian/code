    public void SomeMethod()
    {
    	using (TraceMethod trace = new TraceMethod())
    	{
    	}
    }
    
    public class TraceMethod : IDisposable
    {
    	public TraceMethod() { StartTrace(); }  // Constructor
    	public void Dispose() { EndTrace(); }  // Gets called when leaving the using() block
    
    	private void StartTrace() { ... }
    	private void EndTrace() { ... }
    }
