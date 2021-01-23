    class Timer {
    	private double _time;
    	private readonly IList<ITimerDispatchableEvent> _events;
    	
    	public Timer(double currentTime) {
    	
    	}
    
    	public void Update(double deltaTime) {
    		_time += deltaTime;
    		Dispatch();
    	}
    
    	private void Dispatch() {
    		// Iterate events
    		// if event.FireTime <= _time
    		//   event.Fire();
    	}
    
    	public void AddEvent(ITimerDispatchableEvent event) {
    		_events.add(event);
    	}
    }
    
    public interface ITimerDispatchableEvent {
    	double FireTime { get; }
    	void Fire();
    }
