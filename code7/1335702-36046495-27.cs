    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    public class FancyButton:MonoBehaviour,IPointerDownHandler,IPointerUpHandler
	{
	  public void OnPointerDown(PointerEventData data)
	  {
	      Debug.Log("holy! someone put the pointer down!")
	  }
	
	  public void OnPointerUp(PointerEventData data)
	  {
	      Debug.Log("whoa! someone let go!")
	  }
    }
