    [EventSource]
    class MyEventSource : EventSource
    {
        [Event(...)]
        public void MyEvent(...)
        {
            WriteEvent(...);
        }
    }
    
    es = new MyEventSource();
    es.MyEvent(23, "Hello");
