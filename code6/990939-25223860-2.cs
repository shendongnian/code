    button1.Touch += (s, e) =>
    {
        var handled = false;
        if (e.Event.Action == MotionEventActions.Down)
        {
            // do stuff
            handled = true;
        }
        else if (e.Event.Action == MotionEventActions.Up)
        {
            // do other stuff
            handled = true;
        }
    
        e.Handled = handled;
    };
