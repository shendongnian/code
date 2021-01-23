    [EventSource(Name = "Samples-EventSourceDemos-EventLog")]
    public sealed class MinimalEventSource : EventSource
    {
        public static MinimalEventSource Log = new MinimalEventSource();
    
        [Event(1, Message="{0} -> {1}", Channel = EventChannel.Admin)]
        public void Load(long baseAddress, string imageName)
        {
            WriteEvent(1, baseAddress, imageName);
        }
    }
