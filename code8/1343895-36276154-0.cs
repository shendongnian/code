    using UnityEngine.EventSystems;
    public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    	#region IPointerUpHandler implementation
    	private bool running =false;
    	public void OnPointerUp (PointerEventData eventData)
    	{
    		running = false;
    	}
    
    	#endregion
    
    	#region IPointerDownHandler implementation
    
    	public void OnPointerDown (PointerEventData eventData)
    	{
    		running = true;
    	}
    
    	#endregion
    	
    	// Update is called once per frame
    	void FixedUpdate () 
    	{
    		if(running){ Debug.Log("Doing");}
    	}
    }
