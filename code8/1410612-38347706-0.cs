    bool dblClickDone = false;
    void DoubleClickHandler(...) 
    {
        //...
        dblClickDone = true;
    }
    void MouseDownHandler(...) 
    {
        if (dblClickDone) {
            //...
        }
    }
