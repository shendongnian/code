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
