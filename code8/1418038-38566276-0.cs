    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "Soccer")
                {
                    Debug.Log("Soccer Ball clicked");
                }
    
                //OR with Tag
    
                if (raycastHit.collider.CompareTag("SoccerTag"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }
        }
    }
