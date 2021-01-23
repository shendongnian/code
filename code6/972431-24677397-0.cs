    [ServiceContract(CallbackContract = typeof(IMyServiceCallback),SessionMode = SessionMode.Required)]
    public interface IMyService
    {
        [OperationContract(IsOneWay=true)]
        void DoWork();
    }
