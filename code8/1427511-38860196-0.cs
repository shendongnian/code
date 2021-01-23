    void Main()
    {
    	var a0 = new A();
    	a0.Subscribe();
    	a0.Subscribe();
    	a0.Subscribe();
    	a0.Dispose();
    	a0 = null;
    
    	GC.Collect(); //Has no effect. Demonstrates Garbage collection doesn't help.
    }
    
    class A : IDisposable
    {
    	IObservable<long> poll = Observable.Interval(TimeSpan.FromMilliseconds(100)).Do(l => l.Dump());
    	IDisposable disposable;
    	public void Subscribe()
    	{
    		Dispose();
    		//memory leak!!
    		poll.Subscribe();
    		
    		//Use this instead
                //disposable = poll.Subscribe();
    	}
    	
    	public void Dispose()
    	{
    		disposable?.Dispose();
    	}
    }
