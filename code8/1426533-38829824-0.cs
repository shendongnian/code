    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebInvoke( Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetData" )]
        string GetData(string JsonData);
    }
