    bool validInput = true;
    private void Update()
    {
        validateInput();
        #if UNITY_STANDALONE || UNITY_EDITOR
        //DESKTOP COMPUTERS
        if (Input.GetMouseButtonUp(0) && validInput)
        {
            //Put your code here
            Debug.Log("Valid Input");
        }
        #else
        //MOBILE DEVICES
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && validInput)
        {
            //Put your code here
            Debug.Log("Valid Input");
        }
        #endif
    }
    void validateInput()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        //DESKTOP COMPUTERS
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                validInput = false;
            else
                validInput = true;
        }
        #else
        //MOBILE DEVICES
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                validInput = false;
            else
                validInput = true;
        }
        #endif
    }
