    public RemotingServiceClient serviceClient = new RemotingServiceClient();
    public void Demo()
    {
        using (OperationContextScope scope = new  OperationContextScope(serviceClient.InnerChannel))
        {
            MessageHeader<string> header = new MessageHeader<string>("HeaderValue1");
            var v1 = header.GetUntypedHeader("HeaderName1", "RemotingService");
                           
            OperationContext.Current.OutgoingMessageHeaders.Add(v1);
            
            header = new MessageHeader<string>("HeaderValue2");
            var v2 = header.GetUntypedHeader("HeaderName2", "RemotingService");
            
            OperationContext.Current.OutgoingMessageHeaders.Add(v2);
            
            //IMP: To send headers make sure to call service in this block only.
            //Keep unique uri name "RemotingService"
            return serviceClient.MyRemotingServiceCall();
        }
    }
