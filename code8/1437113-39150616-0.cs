     if(Input.GetMouseButton(0))
     {
         PointerEventData pointer = new PointerEventData(EventSystem.current);
         pointer.position = Input.mousePosition;
 
         List<RaycastResult> raycastResults = new List<RaycastResult>();
         EventSystem.current.RaycastAll(pointer, raycastResults);
 
         if(raycastResults.Count > 0)
         {
             foreach(var go in raycastResults)
             {  
                 Debug.Log(go.gameObject.name,go.gameObject);
             }
         }
     }
