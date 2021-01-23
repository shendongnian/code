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
        static HashSet<IMyServiceCallback> s_allClients = new HashSet<IMyServiceCallback>();
        static object s_lockobj = new object();
        public void Register()
        {
            lock(s_lockobj)
            {
                _allClients.Add(OperationContext.Current.GetCallbackChannel<IMyServiceCallback>());
            }
        }
        public static void SendDataToClients(string data)
        {
            HashSet<IMyServiceCallback> tempSet;
            lock(s_lockobj)
            {
                tempSet = new HashSet<IMyServiceCallback>(_allClients);
            }
            foreach(IMyServiceCallback cb in tempSet)
            {
                try
                {
                    cb.ReceiveData(data);
                }
                catch(Exception)
                {
                    lock(s_lockobj)
                    {
                        _allClients.Remove(cb);
                        cb.Abort();
                        cb.Dispose();
                    }
                }
            }
        }
    }
