    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class UNCDraggable:MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    	{
    	public Image ghost;
    	// note DON'T try to drag the actual item: it's not worth the hassle.
    	// a problem arises where you can't have it on top (as you would want
    	// visually), and still easily get the drops. always use a ghost.
    	// even if you want the "original invisible" while dragging,
    	// simply hide it and use a ghost. everything is tremendously
    	// easier if you do not move the originals.
    	
    	void Awake()
    		{
        	ghost.raycastTarget = false;
        	// (just in case you forgot to do that in the Editor)
    		ghost.enabled = false;
    		}
    	
        public void OnBeginDrag(PointerEventData eventData)
        	{
        	ghost.transform.position = transform.position;
        	ghost.enabled = true;
        	}
    
        public void OnDrag(PointerEventData eventData)
        	{
            ghost.transform.position += (Vector3)eventData.delta;
            }
    
        public void OnEndDrag(PointerEventData eventData)
        	{
        	ghost.enabled = false;
        	}
        
        public void OnDrop(PointerEventData data)
    		{
            GameObject fromItem = data.pointerDrag;
    		if (data.pointerDrag == null) return; // (will never happen)
    		
    		UNCDraggable d = fromItem.GetComponent<UNCDraggable>();
    		if (d == null)
			  {
			  // means something unrelated to our system was dragged from.
			  // for example, just an unrelated scrolling area, etc.
			  // simply completely ignore these.
			  return;
			  // note, if very unusually you have more than one "system"
			  // of UNCDraggable items on the same screen, be careful to
			  // distinguish them! Example solution, check parents are same.
			  }
            
    		Debug.Log ("dropped  " + fromItem.name +" onto " +gameObject.name);
    		
    		// your code would look probably like this:
    		YourThings fromThing = fromItem.GetComponent<YourButtons>().info;
    		YourThings untoThing = gameObject.GetComponent<YourButtons>().info;
    		
    		yourBossyObject.dragHappenedFromTo(fromThing, untoThing);
    		}
    	}
