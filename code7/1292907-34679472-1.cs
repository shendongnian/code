    [ServiceContract(Namespace = "http://Your.Namespace", SessionMode = SessionMode.Required)]
    public interface ICommunicator
    {
        [OperationContract(IsOneWay = false)]
        string StartServer(string serverData);
    } 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CommunicatorService : ICommunicator
    {
        public string StartServer(string serverData)
        {
            //example method that takes a string as input and returns another string
            return "Hello!!!!";
        }
    }
