    void Update()
    {
        //Check if Mouse Button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast from mouse cursor pos
            RaycastHit rayCastHit;
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayCast, out rayCastHit))
            {
                if (rayCastHit.collider.CompareTag("right"))
                {
                    //Your code
                }
                else if (rayCastHit.collider.CompareTag("left"))
                {
                    //Your code
                }
                else if (rayCastHit.collider.CompareTag("up"))
                {
                    //Your code
                }
            }
        }
    }
