	public class LeapEventListener : Listener
	{
		public LeapEventListener(Label lbl)
		{
			if (lbl == null) {
				throw new ArgumentNullException("lbl");
			}
			
			this.lbl = lbl;
		}
		
		private readonly Label lbl;
		
		public override void OnFrame(Controller controller)
		{
			lbl.Text = "New Frame";
			// process frame data...
		}
		public override void OnInit(Controller controller)
		{
			lbl.Text = "Initialized";
		}
		public override void OnConnect(Controller controller)
		{
			lbl.Text = "Connected";
			//If using gestures, enable them:
			controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
		}
		//Not dispatched when running in debugger
		public override void OnDisconnect(Controller controller)
		{
			lbl.Text = "Disconnected";
		}
	}
