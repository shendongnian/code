    public  static  class   PubSub<TMessage>
    {
        private static  List<Action<TMessage>>  listeners   = new List<Action<TMessage>>();
        public  static  Listen(Action<Message> listener)
        {
            if (listener != null)   listeners.Add(listener);
        }
        public  static  Unlisten(Action<TMessage> listener)
        {
            if (listeners.Contains(listener))   listeners.Remove(listener);
        }
        public  static  Broadcast(TMessage message)
        {
            foreach(var listener in listeners)  listener(message);
        }
    }
