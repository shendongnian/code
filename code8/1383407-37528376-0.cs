    [ServiceContract]
    public interface IServer
    {
        [OperationContract]
        int DoStuff1();
        [OperationContract]
        int DoStuff2();
    }
    [ServiceContract(Name = nameof(IServer))]
    public interface IAsyncServer
    {
        [OperationContract]
        Task<int> DoStuff1();
        [OperationContract]
        Task<int> DoStuff2();
    }
