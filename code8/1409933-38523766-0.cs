    YourServiceClient client = new YourServiceClient();
    using(new OperationContextScope(client.InnerChannel)) 
    {
        // Add a HTTP Header to an outgoing request
        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        requestMessage.Headers["MySSOCookie"] = "Auth=yes"; //SSOCookie content
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
     
       client.doSomething();
    
    }
