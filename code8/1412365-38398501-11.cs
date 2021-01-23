    [ServiceContract]
    public interface ISrvService()
    {
        [OperationContract]
        bool Ping(); // doesnt need to be async
        [OperationContract]
        Task<string> LongRunningOperation();
    }
