    [System.ServiceModel.ServiceContract(Namespace="http://service.namespace")]
    public interface IMyService 
    {
        [System.ServiceModel.OperationContract(Action="http://service.namespace/SomeServiceMethod", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormat(SupportFaults=true)]
        void SomeServiceMethod(Request request);
    }
