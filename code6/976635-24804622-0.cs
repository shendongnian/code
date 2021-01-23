    public class ClientMessageInspector : IClientMessageInspector
        {
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                var credHeader = new YourCustomHeader
                {
                    UserName = "UserName",
                    Password = "Password"
                };
    
                var typedHeader = new MessageHeader<CustomHeader>(credHeader);
                var untypedHeader = typedHeader.GetUntypedHeader("custom-header", "s");
    
                request.Headers.Add(untypedHeader);
                return null;
            }
    
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                //
            }
        }
