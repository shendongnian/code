    [ServiceContract()]
    public interface IMyService
    {
        [OperationContract]
        bool DoSomthing(string param);
    }
