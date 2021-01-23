    button1.Touch += (s, e) =>
    {
        if (e.Event.Action == MotionEventActions.Down)
        {
            // do stuff
            e.Handled = true;
        }
        else if (e.Event.Action == MotionEventActions.Up)
        {
            // do other stuff
            e.Handled = true;
        }
    
        e.Handled = false;
    };
