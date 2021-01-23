    void Main()
    {
    	concurrentDictionary[1] = new MyObject(1);
    	DoStuff(1);
    }
    
    private ConcurrentDictionary<int, MyObject> concurrentDictionary = 
        new ConcurrentDictionary<int, UserQuery.MyObject>();
    
    private async void DoStuff(int objectKey)
    {
    	MyObject myObject;
    
    	if (this.concurrentDictionary.TryRemove(objectKey, out myObject))
    	{
    		Action<MyObject> eventsCompletedDelegate = (objectRef) =>
    		{
    			objectRef.DoSomething();
    		};
    		var x = myObject;
    		// myObject.Dispose(); // will set _id to 0 if called
    		myObject = null;
    
    		await ExecuteStuffAsync(() => eventsCompletedDelegate(x));
    	}
    }
    
    public async Task ExecuteStuffAsync(Action callback)
    {
    	await Task.Delay(1000);
    	callback();
    }
    
    
    public class MyObject : IDisposable
    {
    	private int _id;	
    	public MyObject(int id)
    	{
    		_id = id;	
    	}
    
    	public void Dispose() { _id = 0; }
    
    	public void DoSomething()
    	{
    		Console.WriteLine("reached DoSomething " + _id);
    	}
    }
