    [ServiceContract]
    public interface IMyServiceCallback 
    {
        [OperationContract]
        int GetClientId();
        [OperationContract(IsOneWay = true)]
        void WorkComplete();
        [OperationContract(IsOneWay = true)]
        void RecieveMessage(String msg);
    }
