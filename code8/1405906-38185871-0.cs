        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponent<Text>().name);
               
            }
 
