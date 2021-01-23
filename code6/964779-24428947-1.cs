    public class IServiceClient
    {
        IObservable<DateTime> LastConnnected { get; }
    }
    
    public class ServiceClient : IServiceClient, IDisposable
    {
        private readonly IDisposable _connection;
        private readonly IObservable<DateTime> _lastConnnected;
        
        public ServiceClient()
        {
            //Question 1) where does the 'Connected' sequence come from i.e. what is it that tells you that you have internet connectivity?
            //Question 2) When should the subscription be made to 'Connected'? Here I cheat and do it in the ctor, not great.
            var connected = Connected.Replay(1)
                                    .Where(isConnected=>isConnected)
                                    .Take(1)
                                    .Select(_=>DateTime.UtcNow);
                    
            _lastConnnected = connected;
            _connection = connected.Connect();
        }
        
        public IObservable<DateTime> LastConnnected{ get {return _lastConnnected; } }
        
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
