    void FixedUpdate()
    {
        if (isMoving) Timer();
        else // this is same as else if(isMoving == false)
        {
            //isMoving = true;   //<- When I uncomment this, the problem occurs
        }
    }
