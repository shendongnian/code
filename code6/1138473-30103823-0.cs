    void pp_TouchDown(object sender, TouchEventArgs e)
    {
        var pushpin = (Pushpin)sender;
        pushpin.CaptureTouch(e.TouchDevice);
        e.Handled = true
    }
    
    void pp_TouchUp(object sender, TouchEventArgs e)
    {
       var pushpin = (Pushpin)sender;
        if (pushpin != null && e.TouchDevice.Captured == pushpin)
        {
            pushpin.ReleaseTouchCapture(e.TouchDevice);
            ScrollPushPin(pushpin);
        }
        e.Handled = true
    }
