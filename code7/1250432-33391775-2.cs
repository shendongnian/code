    public class LeapEventListener : Listener
    {
    	private string status = string.Empty;
    
    	public string Status { get { return status; } }
    
        public event EventHandler StatusChanged;
    
    	private void SetStatus(string value)
    	{
    		if (value == null) value = string.Empty;
    		status = value;
    		var handler = StatusChanged;
    		if (handler != null) handler(this, EventArgs.Empty);
    	}
    
    	public override void OnFrame(Controller controller)
    	{
            SetStatus("New Frame");
    		// process frame data...
    	}
    
    	public override void OnInit(Controller controller)
    	{
    		SetStatus("Initialized");
    	}
    
    	public override void OnConnect(Controller controller)
    	{
    		SetStatus("Connected");
    		//If using gestures, enable them:
    		controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
    	}
    
    	//Not dispatched when running in debugger
    	public override void OnDisconnect(Controller controller)
    	{
    		SetStatus("Disconnected");
    	}
    }
