    class SendsEvent
    {
        public event EventHandler MyEvent;
        public void FireEvent()
        {
            if(MyEvent != null) // MyEvent is null if no handlers have been attached
            {
                MyEvent(this, new EventArgs()); // event fired here
            }
        }
    }
    class ReceivesEvent
    {
        private SendsEvent eventSource;
        public ReceivesEvent(SendsEvent eventSource)
        {
            this.eventSource = eventSource;
            this.eventSource.MyEvent += (sender, args) =>
            {
                // do something when event was fired
                Console.Out.WriteLine("Hello. Event was fired.");
            };
        }
    }
    class Program
    {
        public static void Main()
        {
            var eventSource = new SendsEvent();
            var eventReceiver = new ReceivesEvent(eventSource);
            eventSource.FireEvent(); 
        }
    }
