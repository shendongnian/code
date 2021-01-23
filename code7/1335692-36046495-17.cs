        using UnityEngine;
        using System.Collections;
        using UnityEngine.EventSystems;
        
        public class FancyButton:MonoBehaviour,IPointerDownHandler,IPointerUpHandler
        	{
        	[System.NonSerialized] public bool mouseIsDownRightNow;
         	
        	public void OnPointerDown(PointerEventData data)
        		{
        		mouseIsDownRightNow = true;
        		}
        	
        	public void OnPointerUp(PointerEventData data)
        		{
        		mouseIsDownRightNow = false;
        		}
        	}
    
    You could access that variable from another script, or whatever you want.
    
    Add the following if you want to run a routine while the button is down:
    
    
    	void Update()
    		{
    		if (buttonIsDownRightNow) WhileButtonIsDown();
    		}
    	private void WhileButtonIsDown()
    		{
    		Debug.Log("THE #$@#$ BUTTON IS DOWN!!!!!!!! WHOA!");
    		}
     	
    Try that and watch the console as you hold the button down and up.
    
    Here's an example of something like continually increasing a value while the button is down:
    
    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    
    public class FancyButton:MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    	{
    	[System.NonSerialized] public bool buttonIsDownRightNow;
     	private int countSomething;
     	
    	public void OnPointerDown(PointerEventData data)
    		{
    		buttonIsDownRightNow = true;
    		}
    	
    	public void OnPointerUp(PointerEventData data)
    		{
    		buttonIsDownRightNow = false;
    		}
    	
    	private void WhileButtonIsDown()
    		{
    		++countSomething;
    		}
     	
    	void Update()
    		{
    		if (buttonIsDownRightNow) WhileButtonIsDown();
    		
    		Debug.Log("value is now " +countSomething.ToString());
    		}
    	}
