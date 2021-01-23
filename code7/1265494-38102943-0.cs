    [DataContract]
    public class ApiResponse
    {
      [DataMember]
      public string Version { get { return "1.2.3"; } }
      [DataMember]
      public int StatusCode { get; set; }
      [DataMember(EmitDefaultValue = false)]
      public string ErrorMessage { get; set; }
      [DataMember(EmitDefaultValue = false)]
      public object Result { get; set; }
      public ApiResponse(HttpStatusCode statusCode, object result = null, string   errorMessage = null)
      {
          StatusCode = (int)statusCode;
          Result = result;
          ErrorMessage = errorMessage;
      }
    }
