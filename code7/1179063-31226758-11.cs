    public class MyClass
    {
        public event EventHandler MyEvent;
        public void setSingleEventHandler(EventHandler eventHandler)
        {
            this.MyEvent = eventHandler;
        }
    }
