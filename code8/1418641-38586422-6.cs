    [ServiceContract]
    public interface IConnService
    {
        [OperationContract]
        bool IsConnected();
    }
