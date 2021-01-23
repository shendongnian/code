       public class MyMessageInspector : IDispatchMessageInspector
        {
            List<string> targetOperations = new List<string>();
    
            public MyMessageInspector(OperationDescription operation)
            {
                this.AddOperation(operation);
            }
    
            public void AddOperation(OperationDescription operation)
            {
                this.targetOperations.Add(operation.Messages[0].Action);
            }
    
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                if (TargetOperationMatchesRequest(request))
                {
                    request = ChangeMessage(request);
    
                    return true;
                }else
                {
                    return false;
                }
            }
    
    
            public bool TargetOperationMatchesRequest(Message request)
            {
                string requestAction = request.Headers.To.AbsolutePath;
                requestAction =  requestAction.Substring(requestAction.LastIndexOf("/"));
    
                string targetOperation = "";
                foreach (string targetOperationPath in targetOperations)
                {
                    targetOperation = targetOperationPath.Substring(targetOperationPath.LastIndexOf("/"));
                    if (targetOperation.Equals(requestAction))
                    {
                        return true;
                    }
                }
                return false;
            }
    
    
            public Message ChangeMessage(Message oldMessage)
            {
                Message newMessage = request.CreateBufferedCopy(Int32.MaxValue).CreateMessage();
                //Change your message
                return newMessage;
    
            }
        
    
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
            }
        }
