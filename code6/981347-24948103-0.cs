        public class MyServiceBehaviorAttribute : Attribute, IServiceBehavior
        {
            public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
                foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
                {
                    foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                    {
                        epDisp.DispatchRuntime.MessageInspectors.Add(new Inspector());
                        foreach (DispatchOperation op in epDisp.DispatchRuntime.Operations)
                            op.ParameterInspectors.Add(new Inspector());
                    }
                }
            }
            public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
            }
        }
        public class Inspector : IDispatchMessageInspector, IParameterInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                Console.WriteLine("IDispatchMessageInspector.AfterReceiveRequest called.");
                return null;
            }
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                Console.WriteLine("IDispatchMessageInspector.BeforeSendReply called.");
            }
            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
                Console.WriteLine(
                  "IParameterInspector.AfterCall called for {0} with return value {1}.",
                  operationName,
                  returnValue.ToString()
                );
            }
            public object BeforeCall(string operationName, object[] inputs)
            {
                Console.WriteLine("IParameterInspector.BeforeCall called for {0}.", operationName);
                return null;
            }
        }
