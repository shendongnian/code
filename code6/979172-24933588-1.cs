    class XsdValiationBehavior : IEndpointBehavior
    {
        private readonly XmlSchemaSet _schemas;
    
        public XsdValidationBehavior(XmlSchemaSet schemas)
        {
            this._schemas = schemas;
        }
    
        public void AddBindingParameters(
            ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters) {}
    
        public void ApplyClientBehavior(
            ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(
                new XsdValidationInspector(this._schemas));
        }
    
        public void ApplyDispatchBehavior(
            ServiceEndpoint endpoint,
            EndpointDispatcher endpointDispatcher) {}
    
        public void Validate(ServiceEndpoint endpoint){}
    }
