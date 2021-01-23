    public interface IHelloWorld
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]        
        HelloWorldResponse Hello(HelloWorldAsk request);
    }
