    public class EventContainer : MonoBehaviour
	{
		public event Action<string> OnShow;
		public event Action<string,float> OnHide;
		public event Action<float> OnClose;
		void Show()
		{
			Debug.Log("Time to fire OnShow event");
			if(OnShow != null)
			{
				OnShow("This string will be received by listener as arg");
			}
		}
		void Hide()
		{
			Debug.Log("Time to fire OnHide event");
			if(OnHide != null)
			{
				OnHide ("This string will be received by listener as arg", Time.time);
			}
		}
		void Close()
		{
			Debug.Log("Time to fire OnClose event");
			if(OnClose!= null)
			{
				OnClose(Time.time); // passing float value.
			}
		}
	}
