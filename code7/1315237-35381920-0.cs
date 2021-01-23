    using UnityEngine;
    using System.Collections;
    
    public class RayCastPoint : MonoBehaviour 
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
    
            RaycastHit2D hit2D = Physics2D.Raycast(touchPostion, Vector2.zero);
    
            return hit2D.collider != null ? hit2D.collider.gameObject : null;
        }
    
    }
