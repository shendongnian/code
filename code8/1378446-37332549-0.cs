    void Main()
    {
	    var generator = new EventGenerator();
	
	    // buffer until the event is called 100 times or when a minute has passed, whatever comes first
	    var subscription = Observable.FromEventPattern<MyEventArgs>(
          	h => generator.MyEvent += h,
          	h => generator.MyEvent -= h)
		.Buffer(TimeSpan.FromMinutes(1), 100)  
		.Subscribe(e => {}); // do something with the data
	    // other code
        while(true)
	    {
	    	Thread.Sleep(500);
	    	generator.RaiseEvent(++count);
	    }
	    // call subscription.Dispose when the eventhandler is no longer needed
    }
    class EventGenerator
    {
	    public event EventHandler<MyEventArgs> MyEvent;
	
	    public void RaiseEvent(object data)
	    {
		    if(MyEvent != null)
		    	MyEvent(this, new MyEventArgs());
	    }
    }
    class MyEventArgs : EventArgs
    {
	    public int Fallbacks {get;set;}
        public int Total {get;set;}
        public int Failures {get;set;}    
    }
