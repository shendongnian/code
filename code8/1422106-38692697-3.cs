    interface IGenericHandler
    {
        void Start();
        void Stop();
    }
    interface IHandler<M> : IGenericHandler where M : Message
    {
        void SetBroker(IBroker<M> broker);
    }
    class FileHandler : IHandler<FileHandlerMessage>
    {
        private IBroker<FileHandlerMessage> broker;
        public FileHandler()
        {
        }
        public void SetBroker(IBroker<FileHandlerMessage> fileBroker)
        {
            this.broker = fileBroker;
        }
        public void Start()
        {
            // do something
            var message = new FileHandlerMessage();
            broker.Process(message);
        }
        public void Stop()
        {
            // do something
        }
    }
    class TimeHandler : IHandler<TimeHandlerMessage>
    {
        private IBroker<TimeHandlerMessage> broker;
        public void SetBroker(IBroker<TimeHandlerMessage>  broker)
        {
            this.broker = broker;
        }
        public void Start()
        {
            // do something
            var message = new TimeHandlerMessage();
            broker.Process(message);
        }
        public void Stop()
        {
            // do something
            throw new NotImplementedException();
        }
    }
