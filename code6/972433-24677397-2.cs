    [ServiceContract]
    public interface IMyServiceCallback 
    {
        [OperationContract(IsOneWay = true)]
        void WorkComplete();
    }
