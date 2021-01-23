    public interface ICRMRestWebService
    {
    [OperationContract]
    [WebInvoke(Method = "POST",
    RequestFormat = WebMessageFormat.Json,    
    ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.WrappedRequest,
    UriTemplate = "GetLatestContractByContactIdRestMethod")]
    LatestMembershipResponse GetLatestContractByContactIdRestMethod(string contactId, AuthenticateRequest authenticateRequest);
    }
