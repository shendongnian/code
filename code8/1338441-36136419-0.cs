    private GameObject selectedObject;    
    //this part is for detecting touched object.
      
       if ( Input.touchCount == 0 )
             {
                 Touch touch = Input.touches[0];
                 Ray ray = Camera.mainCamera.ScreenPointToRay(touch.position);
                 RaycastHit hit;
                 
                 if ( Physics.Raycast(ray, out hit, 100f ) )
                 {
                     selectedObject = hit.collider.gameobject;
                 }
             }
