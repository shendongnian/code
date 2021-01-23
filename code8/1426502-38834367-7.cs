    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [FaultContract( typeof( MessageUnAuthenticatedFault ))]
        [WebInvoke( Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Process" )]
        ResponseClass Process( TestClass message );
    }
