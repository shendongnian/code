    void Update()
    {
     if (Input.touchSupported)
     {
        Debug.Log("TOUCH IS SUPPORTED");
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            print("touched screen");
        }
     }
     else
     {
        Debug.Log("TOUCH IS NOT SUPPORTED");
        if (Input.GetMouseButtonDown(0))
        {
            print("clicked screen");
        }
     }
    }
