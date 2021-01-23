    public class EventGenerator
    {
        public EventHandler<MyEventArgs> TheEvent;
        public void RaiseEvent(Guid identifier)
        {
            if (TheEvent != null) 
                TheEvent(this, new MyEventArgs(){Identifier = identifier});
        }
    }
