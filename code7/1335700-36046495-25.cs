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
