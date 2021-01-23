    [ServiceContract(Namespace = Namespaces.Example)]
    public interface IExample
    {
        [SoapHeader("MyHeader", typeof(MyHeader), Direction = SoapHeaderDirection.In)]
        [OperationContract]
        string ExampleRequests();
    
    }
