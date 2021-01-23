    delegate void HandlerDelegate<TEvent>(TEvent ev) where TEvent : Event;
    class EventManager
    {
        Dictionary<Type, Delegate> delegateMap = new Dictionary<Type, Delegate>();
    
        public void Dispatch<TEvent>(TEvent ev) where TEvent : Event
        {
            Delegate d;
            if (delegateMap.TryGetValue(typeof(TEvent), out d))
            {
                var handler = (HandlerDelegate<TEvent>)d;
                handler(ev);
            }
        }
    
        public void Register<TEvent>(HandlerDelegate<TEvent> handler) where TEvent : Event
        {
            delegateMap.Add(typeof(TEvent), handler);
        }
    }
