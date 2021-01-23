    [ServiceContract(CallbackContract = typeof(IMyServiceCallback))]
    public interface IMyService
    {
        [OperationContract]
        void Register();
    }
