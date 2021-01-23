    [EventSource(Name = "HelloEventSource")]
    internal sealed class HelloEventSource : EventSource
    {
        [Event(1, Level = EventLevel.Informational, Message = "Hello World! {0}")]
        public void HelloWorld(string name)
        {
            WriteEvent(1, name);
        }
    }
