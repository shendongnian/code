    // define a ‘plain old data’ class 
        [EventData]
        class SimpleData {
            public string Name { get; set; }
            public int Address { get; set; }
        }
    
        [EventSource(Name = "Samples-EventSourceDemos-RuntimeDemo")]
        public sealed class RuntimeDemoEventSource : EventSource
        {
            // define the singleton instance of the event source
            public static RuntimeDemoEventSource Log = new RuntimeDemoEventSource();
            // Rich payloads only work when the self-describing format 
            private RuntimeDemoEventSource() : base(EventSourceSettings.EtwSelfDescribingEventFormat) { }
    
            // define a new event. 
            public void LogSimpleData(string message, SimpleData data) { WriteEvent(1, message, data); }
        }
    RuntimeDemoEventSource.Log.LogSimpleData(
            "testMessage", 
            new SimpleData() { Name = "aName", Address = 234 });
