    [ServiceContract]
    public interface IDummyRest 
    {    
        [OperationContract]
        [WebGet(UriTemplate = "{orderID}/responses",
            ResponseFormat = WebMessageFormat.Json)]
        List<Response> GetResponses(string orderID);
    }
