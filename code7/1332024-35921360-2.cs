    class Timer {
    	private double _time;
    	private readonly IList<ITimerDispatchableEvent> _events;
    	
    	public Timer(double currentTime) {
    	  _time = currentTime
    	}
    
        // Update this on each call back during the main loop
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
        // the absolute time to fire. E.g. if we want to fire in 10seconds
        // this will be Timer._time += 10 (assuming deltaTime is in seconds)
    	double FireTime { get; }
    	void Fire();
    }
