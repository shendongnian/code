    public void Update()
    
    {
        foreach (Touch touch in Input.touches)
        {
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                // you touched at least one UI element
                return;
            }
        }
    
        // you didnt touched any UI element
        // Do Something
    }
