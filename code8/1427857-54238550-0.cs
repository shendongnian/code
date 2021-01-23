    public class LoggingEndpointBehaviour : IEndpointBehavior
    {
        public LoggingMessageInspector MessageInspector { get; }
    
        public LoggingEndpointBehaviour(LoggingMessageInspector messageInspector)
        {
            MessageInspector = messageInspector ?? throw new ArgumentNullException(nameof(messageInspector));
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(MessageInspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
