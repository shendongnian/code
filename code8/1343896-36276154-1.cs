    using UnityEngine.EventSystems;
    public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        [SerializeField]private InputField userField;
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
    		if(running){ BackSpace();}
    	}
        private void BackSpace() {
            string textEnter = userField.text;
            string tempString = textEnter.Substring(0, textEnter.Length - 1);
            userField.text = tempString;
        }
    }
