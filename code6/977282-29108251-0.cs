    public class MyElementHost : ElementHost
    {
        protected override void Dispose(bool disposing)
        {
             base.Dispose(disposing);
             if(disposing)
             {
                 //Use debugging tools to identify handlers and unregister
                 MyEventHandler myEventHandler = (MyEventHandler)Delegate.CreateDelegate(typeof(MyEventHandler), this, "childElement_MyLeakingEvent");
                 FrameworkElement fe = Child as FrameworkElement;
                 if(fe != null)
                    fe.MyLeakingEvent -= myEventHandler;
             }
        }
        Child = null;
        Parent = null;
    }
