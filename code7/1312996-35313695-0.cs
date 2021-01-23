    [OperationContract]
    [WebInvoke(
    BodyStyle = WebMessageBodyStyle.Bare, //or WrappedRequest
    Method = "GET",
    ResponseFormat = WebMessageFormat.Json,		
    UriTemplate = "/somemethod?param1={param1}&param2={param2}")]
    System.ServiceModel.Channels.Message SomeMethod(string param1, string param2)
    {
    	// use JSON.NET to add missing properties etc: 
    	var jObject = JObject.FromObject(yourObject); 
    	jObject["success"] = true; 
    	var json = jObject.ToString();
    	
    	WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
    	return WebOperationContext.Current.CreateTextResponse(json);
    }
