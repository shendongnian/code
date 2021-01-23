    [ServiceContract]
    public interface IWtfService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", 
                   ResponseFormat = WebMessageFormat.Json, 
                   RequestFormat = WebMessageFormat.Json, 
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        void HelloWorldPostComplex(Person person);
    }
