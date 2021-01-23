    public interface ITestService
    {
       [OperationContract]
       [WebGet]
       string HelloWorld(string text)
    }
