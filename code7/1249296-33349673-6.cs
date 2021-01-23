    [ServiceContract]
    public interface IAngularService
    {
      [OperationContract]
      [WebGet(UriTemplate = "/Hello", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
      [Description("Returns hello world json object")]
      HelloWorld GetHello();
    }
    [DataContract]
    public class HelloWorld
    {
      [DataMember]
      public string Message { get; set; }
    }
