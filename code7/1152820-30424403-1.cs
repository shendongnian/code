    if (T.phase == TouchPhase.Began && SwipeID == -1)
    {
        Ray ray = Camera.main.ScreenPointToRay(P);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
             
             if(hit.collider.gameObject == "one of your clone objects")
             {
                  SwipeID = T.fingerId;
                  StartPos = P;
                  MessageTarget = hit.collider.gameObject;
             }
        }
    }
