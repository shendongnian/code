    public static void main () {
    	var eventBus = new EventBus();
    
    	var aRoom = new NoisyRoom(eventBus);
    	var bRoom = new NoisyRoom(eventBus);
    	var cRoom = new NoisyRoom(eventBus);
    	var dRoom = new QuietRoom(eventBus);
    
    	eventBus.Send(new NoisyEvent()); //sends to a,b,c room
    }
    
    public class EasyListeningEvent : IEvent
    {
    }
    public class QuietRoom
    {
    	public QuietRoom(EventBus eventBus)
    	{
    		eventBus.Listen<EasyListeningEvent>(BringTheNaps);
    	}
    
    	private void BringTheNaps(IEvent @event)
    	{
    		//its been brought!
    	}
    }
    
    class NoisyEvent : IEvent
    {
    }
    public class NoisyRoom
    {
    	public NoisyRoom(EventBus eventBus)
    	{
    		eventBus.Listen<NoisyEvent>(BringTheNoise);
    	}
    
    	private void BringTheNoise(IEvent @event)
    	{
    		//its been brought!
    	}
    }
    
    
