    public void GetSwipeDirection()
    {
        //You have to rename the axis's so you can use a joystick and a touch pad
        var horizontal = CrossPlatformInputManager.GetAxis("TouchHorizontal");
        var vertical = CrossPlatformInputManager.GetAxis("TouchVertical");
        //No Touch Occured
        if(vertical == 0 && horizontal == 0)
        {
            return;
        }
        //If they swipe at exactly a 45 register as horizontal so atleast we registered a hit
        if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical))
        {
            if(horizontal > 0)
            {
                if(null != SwipeRight)
                {
                    SwipeRight();
                }
                Debug.Log("Right");
            }
            else
            {
                if (null != SwipeLeft)
                {
                    SwipeLeft();
                }
                Debug.Log("Left");
            }
        }
        else
        {
            if (vertical > 0)
            {
                if (null != SwipeUp)
                {
                    SwipeUp();
                }
                Debug.Log("Up");
            }
            else
            {
                if (null != SwipeDown)
                {
                    SwipeDown();
                }
                Debug.Log("Down");
            }
        }
    }
