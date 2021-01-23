    bool dragging = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            yourOnMouseDownFunction();
            dragging = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            yourOnMouseUpFunction();
            dragging = false;
        }
        if(dragging )
        {
            yourOnMouseDragFunction();
        }
    }
