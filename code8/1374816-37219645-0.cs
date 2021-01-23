    public class MyClass<T>
    {
        private Dictionary<T, List<IEventProcessor<T>>> _subscribers = new Dictionary<T, List<IEventProcessor<T>>> ();
        public GenEvent<T> GetEvent () {}
        
        public void Process<T>()
        {
            GenEvent<T> ev = GetEvent();
            List<IEventProcessor<T>> list;
            if (_subscribers.TryGetValue(ev.EType,  out list) )
            {
                foreach (var sub in list) 
                {
                    // do something 
                }
            }
        }
    }
