    [Register("MyApplication")]
    public class MyApplication : UIApplication
    {
        public override void SendEvent(UIEvent uievent)
        {
            base.SendEvent(uievent);
            var allTouches = uievent.AllTouches;
            if (allTouches.Count > 0)
            {
                var phase = ((UITouch)allTouches.AnyObject).Phase;
                if (phase == UITouchPhase.Began || phase == UITouchPhase.Ended)
                    ResetIdleTimer();
            }
        }
    }
