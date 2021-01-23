    private Windows.System.Display.DisplayRequest _displayRequest;
     
    public void ActivateDisplay()
    {
        //create the request instance if needed
        if (_displayRequest == null)
            _displayRequest = new Windows.System.Display.DisplayRequest();
     
        //make request to put in active state
        _displayRequest.RequestActive();
    }
     
    public void ReleaseDisplay()
    {
        //must be same instance, so quit if it doesn't exist
        if (_displayRequest == null)
            return;
     
        //undo the request
        _displayRequest.RequestRelease();
    }
