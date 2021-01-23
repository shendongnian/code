        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetOrdersJSON?ClientID={ClientID}&SenderEmail={SenderEmail}&VersionNumber={VersionNumber}")]
        [ServiceKnownType(typeof(List<MyCustomErrorDetail>))]
        [ServiceKnownType(typeof(List<ShipToDetails>))]
        object GetOrdersJSON(int ClientID, string SenderEmail, string VersionNumber);
    [DataContract]
    public class MyCustomErrorDetail
    {
        public MyCustomErrorDetail(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }
        [DataMember]
        public string ErrorInfo { get; private set; }
        [DataMember]
        public string ErrorDetails { get; private set; }
    }
