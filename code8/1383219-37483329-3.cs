    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    	
    	
    	
    	public void OnBeginDrag(PointerEventData eventData) {
    		
    	}
    	
    	public void OnDrag(PointerEventData eventData) {
    		//Debug.Log ("OnDrag");
    		
    		this.transform.position = eventData.position;
   
    		}
    	public void OnEndDrag(PointerEventData eventData) {
    		Debug.Log ("OnEndDrag");
    	
        }
    }
