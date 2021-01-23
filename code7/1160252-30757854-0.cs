    [ServiceContract]
    public interface IClass
    {
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, 
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "/GET/?json={jsonString}", Method = "GET")]
        string Decode(string jsonString);
    
    
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, 
       BodyStyle = WebMessageBodyStyle.Bare,
       UriTemplate = "/POST/?json={jsonString}", Method = "POST")] 
       string DecodePost(string jsonString);
    }
