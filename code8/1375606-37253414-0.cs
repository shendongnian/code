    if (Input.touchCount > 0)
    {
        for (int i = 0; i < Input.touchCount; i++) 
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i));
            
            // if(touchPos.x is on my side)
            // {
            //    myTouch = touchPos;
            // }
        }
    }
