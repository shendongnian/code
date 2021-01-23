    public  static  class   PubSub<TMessage>
    {
        private static  List
                        <
                            Action
                            <
                                TMessage
                            >
                        >                   listeners   = new List<Action<TMessage>>();
        public  static  void                Listen(Action<TMessage> listener)
        {
            if (listener != null)   listeners.Add(listener);
        }
        public  static  void                Unlisten(Action<TMessage> listener)
        {
            if (listeners.Contains(listener))   listeners.Remove(listener);
        }
        public  static  void                Broadcast(TMessage message)
        {
            foreach(var listener in listeners)  listener(message);
        }
    }
