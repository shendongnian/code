        [EventSource(Guid = "{GUID of EventSource}", Name = "SourceName")] 
        class MyEventSource : EventSource
        {
            public void MyEvent(string msg, int id) { WriteEvent(1, msg, id); }
            public static MyEventSource Log = new MyEventSource();
        }
