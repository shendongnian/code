    using UnityEngine.EventSystems;
    public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        [SerializeField]private InputField userField;
    	#region IPointerUpHandler implementation
    	private bool running =false;
    	public void OnPointerUp (PointerEventData eventData)
    	{
    		running = false;
            if(timer < holdTime){ Tap(); }
            timer = 0.0f;
    	}
    
    	#endregion
    
    	#region IPointerDownHandler implementation
    
    	public void OnPointerDown (PointerEventData eventData)
    	{
    		running = true;
    	}
    
    	#endregion
    	float timer = 0.0f;
        float holdTime = 0.25f;
    	// Update is called once per frame
    	void FixedUpdate () 
    	{
    		if(running){ 
               timer += Time.deltaTime;
               if(timer > holdTime)
                    BackSpace();}
    	}
        private void BackSpace() {
            string textEnter = userField.text;
            string tempString = textEnter.Substring(0, textEnter.Length - 1);
            userField.text = tempString;
        }
    }
