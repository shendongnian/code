    public interface IServiceClient
    {
        IObservable<DateTime> LastConnnected { get; }
    }
    
    public class ServiceClient : IServiceClient, IDisposable
    {
        private readonly IDisposable _connection;
        private readonly IObservable<bool> _lastConnnected;
    
        public ServiceClient(IObservable<ConnectionState> connectedStates)
        {
            var cachedStates = connectedStates.Select(state=>state.IsConnected).Replay(1);
            _lastConnnected = cachedStates;
            _connection = cachedStates.Connect();
        }
    
        public IObservable<DateTime> LastConnnected
        { 
            get 
            {
                return _lastConnnected.StartWith(IsConnected())
                                      .Where(isConnected=>isConnected)
                                      .Take(1)
                                      .Select(_=>DateTime.UtcNow); 
            } 
        }
        
        //....
    
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
