    public class AsyncRunner : IAsyncRunner
    {
    	private ILifetimeScope _lifetimeScope { get; set; }
    
    	public AsyncRunner(ILifetimeScope lifetimeScope)
    	{
    		//Guard.NotNull(() => lifetimeScope, lifetimeScope);
    		_lifetimeScope = lifetimeScope;
    	}
    
    	public Task Run<T>(Action<T> action)
    	{
    		Task.Factory.StartNew(() =>
    		{
    			using (var lifetimeScope = _lifetimeScope.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
    			{
    				var service = lifetimeScope.Resolve<T>();
    				action(service);
    			}
    		});
    		return Task.FromResult(0);
    	}
    
    
    }
