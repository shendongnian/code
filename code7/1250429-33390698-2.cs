	public abstract class LeapEventListener : Listener
	{
		protected abstract void DisplayStatus(string message);
		
		public override void OnFrame(Controller controller)
		{
			DisplayStatus("New Frame");
			// process frame data...
		}
		public override void OnInit(Controller controller)
		{
			DisplayStatus("Initialized");
		}
		public override void OnConnect(Controller controller)
		{
			DisplayStatus("Connected");
			//If using gestures, enable them:
			controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
		}
		//Not dispatched when running in debugger
		public override void OnDisconnect(Controller controller)
		{
			DisplayStatus("Disconnected");
		}
	}
	
	public class LabelLeapEventListener : LeapEventListener
	{
		public LabelLeapEventListener(Label lbl)
		{
			if (lbl == null) {
				throw new ArgumentNullException("lbl");
			}
			
			this.lbl = lbl;
		}
		
		private readonly Label lbl;
		
		protected override void DisplayStatus(string message)
		{
			lbl.Text = message;
		}
	}
