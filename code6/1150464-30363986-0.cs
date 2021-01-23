    [ServiceContract]
        public interface IMyservice
        {
            [OperationContract]
            void DoWork();
    
            [OperationContract]
            string GetMessage(string name);
        }
    
        public class MyServiceMessageInspector:System.ServiceModel.Dispatcher.IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request,System.ServiceModel.IClientChannel channel,
                System.ServiceModel.InstanceContext instanceContext)
            {
                if(request.Headers.FindHeader("LisenseKey","")==-1)
                {
                    throw new FaultException("Lisense Key Was Not Provided");
                }
    
                var lisenseKey = request.Headers.GetHeader<string>("LisenseKey", "");
                if (string.IsNullOrEmpty(lisenseKey))
                {
                    throw new FaultException("Lisnse key is not valid");
                }
    
                if(lisenseKey!="12345x")
                {
                    throw new FaultException("Lisense key is not valid");
                }
    
                return instanceContext;
            }
    
            public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply,object correlationState)
            {
    
            }
        }
    
        public class MyServiceMessageInspectorBehaviour:Attribute,System.ServiceModel.Description.IServiceBehavior
        {
            public void AddBindingParameters(System.ServiceModel.Description.ServiceDescription serviceDescription,
                System.ServiceModel.ServiceHostBase serviceHostBase,
                System.Collections.ObjectModel.Collection<System.ServiceModel.Description.ServiceEndpoint> endpoints,
                System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
    
            }
    
            public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceDescription serviceDescription,
                System.ServiceModel.ServiceHostBase serviceHostBase)
            {
                foreach(ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
                {
                    foreach(var endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MyServiceMessageInspector());
                    }
                }
            }
    
            public void Validate(System.ServiceModel.Description.ServiceDescription serviceDescription,System.ServiceModel.ServiceHostBase serviceHostBase)
            {
    
            }
        }
