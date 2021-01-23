    public interface IMyDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyMeOf(string message);
    }
