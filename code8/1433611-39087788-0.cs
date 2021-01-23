    using UnityEngine;using System.Collections;
    using UnityEngine.EventSystems;
    
    public class Test : MonoBehaviour,IPointerEnterHandler 
    {
    	public void OnPointerEnter(PointerEventData eventData)
    	{
    		GameObject currentGo;
    		currentGo = eventData.pointerEnter;
    		if (currentGo.tag == "GameObjectWithCollider2D" || currentGo.GetComponent<BoxCollider2D>()) 
    		{
    			Debug.Log ("This has Box Collider 2D");	
    		}
    	}
    }
