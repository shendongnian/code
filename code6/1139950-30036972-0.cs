	public interface IEventListener<TEvent> where TEvent: IEvent
	{
	    void Handle(TEvent @event);
	}
	class MyEventHandler : IEventListener<SomeEvent>
	{
	   public void Handle(SomeEvent @event)
	   {
	       // Handle the event of course
	   }
	}
