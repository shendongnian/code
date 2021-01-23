    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json,UriTemplate="/getdata")]
        string GetData();
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }
