    class Foo
    {
    	private EventHandler<EventArgs> anEvent;
    	
    	public void add_anEvent(EventHandler<EventArgs> delegateToAdd)
    	{
    		//some code to make this safe, but basically calls-ish:
    		anEvent = System.Delegate.Combine(anEvent, delegateToAdd);
    	}
    	
    	public Foo()
    	{
    		Console.WriteLine(anEvent == null); // true
    		//your += operator is converted to a call to "add_Event" instead
    		add_anEvent((sender, args) => { var i = 0; };);
    	}
    }
