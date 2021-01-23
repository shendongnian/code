    void Update()
    {
        //Check for Press
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
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
    
            //Check if we moved the finger(while press is still down)
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
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
                Debug.Log("Released Finger!");
            }
        }
    }
