        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = @"*")]
        GenericResponse Post(GenericRequest request);
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = @"*")]
        GenericResponse Get();
