    public class Listener : MonoBehaviour
    {
    
    	void Awake()
    	{
    		EventContainer.OnGameFailedEvent += EventContainer_OnGameFailedEvent;
    	}
    
    	void EventContainer_OnGameFailedEvent (string value)
    	{
    		StartCoroutine(MyCoroutine(value));
    	}
    	
    	IEnumerator MyCoroutine(string someParam)
    	{
    		yield return new WaitForSeconds(5);
    
    		Debug.Log(someParam);
    	}
    
    }
