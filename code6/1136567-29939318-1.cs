    public class Mediator
    {
        readonly Dictionary<Type, List<object>> _handlersByType = new Dictionary<Type, List<object>>();
        public void Register<Tmessage>(Action<Tmessage> callback)
        {
            List<object> handlers;
            if (!_handlersByType.TryGetValue(typeof(Tmessage), out handlers))
                _handlersByType[typeof(Tmessage)] = handlers = new List<object>();
            
            handlers.Add(callback);
        }
        public void Dispatch<Tmessage>(Tmessage msg)
        {
            List<object> handlers;
            if (!_handlersByType.TryGetValue(typeof(Tmessage), out handlers))
                return;
            foreach (Action<Tmessage> handler in handlers)
                handler(msg);
        }
    }
    
