    Vector3 lastPos;
    
    void Update()
    {
        //Check for Press
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                lastPos = Input.GetTouch(i).position;
                Vector2 fingerRay = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                RaycastHit2D objectHit = Physics2D.Raycast(fingerRay, Vector2.zero);
                if (objectHit)
                {
                    //We hit something
                    if (objectHit.collider.name == "myGameObjectName")
                    {
                        Debug.Log("Touched Finger on GameObject: " + objectHit.collider.name);
                    }
                }
            }
    
            //Get current Pos
            Vector3 currentPos = Input.GetTouch(i).position;
    
            //Check if we moved
            if (currentPos != lastPos)
            {
                //Update Last Pos
                lastPos = currentPos;
                Debug.Log("Finger Moved!" + lastPos);
    
                Vector2 fingerRay = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                RaycastHit2D objectHit = Physics2D.Raycast(fingerRay, Vector2.zero);
                if (objectHit)
                {
                    //We hit something while moving the finger
                    if (objectHit.collider.name == "myGameObjectName")
                    {
                        Debug.Log("Moved Finger on GameObject: " + objectHit.collider.name);
                    }
                }
            }
    
            //Check for release
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                // Debug.Log("Released Finger!");
            }
        }
    }
