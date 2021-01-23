    using UnityEngine;
    using System.Collections;
    
    public class RayCastMultiple : MonoBehaviour 
    {
        public Camera MainCamera;
    
        private const float MAX_DISTANCE = 100f;
    
    	// Use this for initialization
    	void Start () 
        {
            if(MainCamera == null)
                Debug.LogError("No MainCamera");
    	}
    	
    	// Update is called once per frame
    	void FixedUpdate () 
        {
            if(Input.GetMouseButtonDown(0))
            {
                var mouseSelection = CheckForObjectUnderMouse();
                if(mouseSelection == null)
                {
                    Debug.Log("nothing selected by mouse");
                }
                else
                {
                    Debug.Log(mouseSelection.gameObject);
                }
            }
    	}
    
        private GameObject CheckForObjectUnderMouse()
        {
            Vector2 touchPostion = MainCamera.ScreenToWorldPoint(Input.mousePosition);
    
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(touchPostion, Vector2.zero);
    
    
            SpriteRenderer closest = null;
            foreach(RaycastHit2D hit in hits2D)
            {
                if(closest == null)
                {
                    closest = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    continue;
                }
                    
                var hitSprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
    
                if(hitSprite == null)
                    continue; //If the object has no sprite go on to the next hitobject
    
                if(hitSprite.sortingOrder > closest.sortingOrder)
                    closest = hitSprite;
            }
    
            return closest != null ? closest.gameObject : null;
        }
    
    }
