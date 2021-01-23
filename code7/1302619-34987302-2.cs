    public sealed class Notifications
    {
        public event EventHandler MyEvent;
    
        internal void RaiseMyEvent(EventArgs e)
        {
            var myEvent = MyEvent;
            if (myEvent != null)
                myEvent(this, e);
        }
    }
    
    class MyAction
    {
        public Notifications Notifications
        {
            get { return _notifications; }
        }
    
        // ...
    }
    
    class SubClass
    {
        public Notifications Notifications
        {
            return _action.Notifications; }
        }
        // ...
    }
