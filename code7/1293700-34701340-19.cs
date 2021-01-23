    public class WaitForDelegate : IDisposable
    {
    	private IDisposable _subscription;
    	
        public WaitForDelegate(IObservable<Unit> trigger)
        {
            _subscription = trigger.Subscribe(_ => { Console.WriteLine("trigger"); });
        }
    	
    	public void Dispose()
    	{
    		_subscription.Dispose();
    	}
    }
