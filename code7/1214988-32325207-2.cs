    public class PausingView : MonoBehaviour {
    
    	[SerializeField]
    	private PausableRigidbody _pausableRigidbody;
    
    	public void OnMouseEnter() 
    	{
    		_pausableRigidbody.Pause();
    	}
    	
    	public void OnMouseExit() 
    	{
    		_pausableRigidbody.Resume();
    	}
    }
