    void check2DObjectClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is pressed down");
            Camera cam = Camera.main;
    
            //Raycast depends on camera projection mode
            Vector2 origin = Vector2.zero;
            Vector2 dir = Vector2.zero;
    
            if (cam.orthographic)
            {
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                origin = ray.origin;
                dir = ray.direction;
            }
    
            RaycastHit2D hit = Physics2D.Raycast(origin, dir);
    
            //Check if we hit anything
            if (hit)
            {
                Debug.Log("We hit " + hit.collider.name);
            }
        }
    }
