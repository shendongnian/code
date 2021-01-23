    [DataContract]
    public class Response<T>
    {
    	[DataMember]
    	public T Result { get; set; }
    
    	[DataMember]
    	public int Status { get; set; }
    }
    
    // then your declaration
    Response<List<User>> serverResponse = Response<List<User>>();
    
    // on success
    serverResponse.Result = userList;
    serverResponse.Status = 200; // ok
    
    // on fail
    serverResponse.Status = 500; // fail
    
    // and contract
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/GetUsers")]
    Response<List<User>> GetUsers();
