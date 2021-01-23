    public class CustomWebErrorEvent : WebErrorEvent
    {
        public CustomWebErrorEvent(string message, EventSource source, int eventCode, Exception ex) : base(message, source, eventCode, ex)
        {
        }
    }
