    [ServiceContract(CallbackContract=typeof(IMyServiceCallback))]
    public interface IMyService
    {
        [OperationContract]
        void Register();
    }
    public interface IMyServiceCallback
    {
        [OperationContract]
        void ReceiveData(string data);
    }
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyService : IMyService
    {
        HashSet<IMyServiceCallback> _allClients = new HashSet<IMyServiceCallback>();
        public void Register()
        {
            _allClients.Add(OperationContext.Current.GetCallbackChannel<IMyServiceCallback>());
        }
        public void SendDataToClients(string data)
        {
            foreach(IMyServiceCallback cb in new HashSet<IMyServiceCallback>(_allClients))
            {
                try
                {
                    cb.ReceiveData(data);
                }
                catch(Exception)
                {
                    _allClients.Remove(cb);
                    cb.Abort();
                    cb.Dispose();
                }
            }
        }
    }
