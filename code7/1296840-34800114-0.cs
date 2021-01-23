    public class YourPingClass
    {
        private SynchronizationContext syncContext;
        public YourPingClass()
        {
            syncContext = SynchronizationContext.Current ?? 
                new SynchronizationContext();
        }
    
        private void FireEvent()
        {
            string event_name = "event_" + key;
            EventInfo handler_event = this.GetType().GetEvent(event_name);
            var event_delegate = (MulticastDelegate)this.GetType().GetField(event_name, 
                BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);
            foreach (var handler in event_delegate.GetInvocationList())
            {
                syncContext.Post(_ => handler.Method.Invoke(handler.Target, 
                    new object[] { ((JObject)payload_dict[key]).ToObject<Dictionary<string, object>>() }));
            }
        }
    }
