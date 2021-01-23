    public interface IMessageHandler
    {
        void SendMessage(string message);
    }
    
    public class MessageHandler : IMessageHandler
    {
        private readonly IWorkDispatcher workDispatcher;
    
        public MessageHandlerIWorkDispatcher workDispatcher)
        {
            this.workDispatcher = workDispatcher;
        }
    
        private void OnIncommingMessage(string message)
        {
            workDispatcher.DispatchWork(message);
        }
    
        public void SendMessage(string message)
        {
            //sendMessage code
        }
    }
    
    public interface IService
    {
        void DoWork(string work);
    }
    
    public class Service : IService
    {
        private readonly IMessageDispatcher messageDispatcher
    
        public Service(IMessageDispatcher messageDispatcher)
        {
            messageDispatcher = messageDispatcher;
        }
    
        public void DoWork(string work)
        {
            //Do Work
        }
    
        private void SomeMethodNeedsToPushData(string message)
        {
            messageDispatcher.SendMessage(message);
        }
    
    }
    
    public interface IServiceDispatcher
    {
        void DispatchWork(string work);
    }
    
    public class ServiceDispatcher : IServiceDispatcher
    {
        private readonly IService service;
    
        public MessageHandler(IService service)
        {
            this.service = service;
        }
    
        public void DispatchWork(string work)
        {
            service.DoWork(work);
        }
    }
    
    public interface IMessageDispatcher
    {
        void DispatchMessage(string message);
    }
    
    
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IMessageHandler messageHandler;
    
        public MessageHandler(IMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }
    
        public void DispatchMessage(string message);
        {
            messageHandler.SendMessage(message);
        }
    }
