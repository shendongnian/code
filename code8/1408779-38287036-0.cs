    void validateInput()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject.CompareTag("invisible"))
                validInput = true;
            else if (EventSystem.current.IsPointerOverGameObject())
                validInput = false;
            else
                validInput = true;
        }
    
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && EventSystem.current.currentSelectedGameObject.CompareTag("invisible"))
                validInput = true;
            else if (EventSystem.current.IsPointerOverGameObject())
                validInput = false;
            else
                validInput = true;
        }
    }
