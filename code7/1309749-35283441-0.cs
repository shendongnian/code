    public sealed class EventSourceWriter : EventSource
    {
        public static EventSourceWriter Logger = new EventSourceWriter();
    
        [Event(1, Level = EventLevel.Informational)]
        public void LogInformational(string message)
        {
            WriteEvent(1, message);
        }
        [Event(2, Level = EventLevel.Warning)]
        public void LogWarning(string message)
        {
            WriteEvent(2, message);
        }
        [Event(3, Level = EventLevel.Error)]
        public void LogError(string message)
        {
            WriteEvent(3, message);
        }
    }
