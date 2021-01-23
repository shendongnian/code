    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    public class FancyButton:MonoBehaviour,IPointerDownHandler,IPointerUpHandler
	{
	  public void OnPointerDown(PointerEventData data)
	  {
	      Debug.Log("holy! someone clicked down!")
	  }
	
	  public void OnPointerUp(PointerEventData data)
	  {
	      Debug.Log("whoa! someone clicked up!")
	  }
    }
