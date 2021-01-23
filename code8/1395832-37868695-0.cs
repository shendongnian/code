    void Update(){
        // Get pointer events
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        
        // Test the raycast
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);
        
        // Check if anything was cast
        if(Input.GetMouseButtonUp(0) && raycastResults.Count == 0 && prefab){
            Instantiate(prefab, /* At mouse position on ground */);
            prefab = null;
        }
    }
