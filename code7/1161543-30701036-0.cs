    [OperationContract(Name = “PostSampleMethod”)]
        [WebInvoke(Method = “POST”,
         UriTemplate = “PostSampleMethod/New”)]
        string PostSampleMethod(Stream data);
    OperationContract name: GetSampleMethod
    WebGet attribute defined method type is GET
    Need to include below namespaces:
    Hide   Copy Code
    System.ServiceModel.Web;
    System.ServiceModel
    System.Runtime.Serialization
    System.IO
    [OperationContract(Name = “GetSampleMethod”)]
        [WebGet(UriTemplate = “GetSampleMethod/inputStr/{name}”)]
        string GetSampleMethod(string name);
