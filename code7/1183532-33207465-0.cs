    // In AddedToScene
    var touchListener =  new CCEventListenerTouchAllAtOnce();
    touchListener.OnTouchBegan = this.OnTouchesBegan;
    AddEventListener(touchListener,this);
    // Handler
    void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
    {
        if ( quitItem.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location ))
                {
                    // print message here
                }
    }
