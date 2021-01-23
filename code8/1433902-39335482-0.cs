    public class EventContainer : MonoBehaviour
    {
    	public static event Action<string> OnGameFailedEvent;
    
		void Update()
		{
			if (Input.GetKey(KeyCode.R))
			{
				// fire the game failed event when user press R.
				if(OnGameFailedEvent = null)
					OnGameFailedEvent("some value");
			}
		}
    }
    
