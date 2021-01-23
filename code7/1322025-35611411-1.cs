    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, UriTemplate = "/getPost/{value}")]//change here 
        string getPost(string value);
       
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }
