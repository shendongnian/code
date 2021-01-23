    class Manager
    {
        private List<IGenericHandler> handlers = new List<IGenericHandler>();
        public void Register<M>(IHandler<M> handler, IBroker<M> broker) where M : Message
        {
            handlers.Add(handler);
        }
        public void Start()
        {
            foreach ( var handler in handlers )
            {
                handler.Start();
            }
        }
        public void Stop()
        {
            foreach (var handler in handlers)
            {
                handler.Stop();
            }
        }
    }
