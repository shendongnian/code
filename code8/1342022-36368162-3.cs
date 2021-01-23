    public class RoyalMailCustomMessage : Message
    {
        private readonly Message message;
        public RoyalMailCustomMessage(Message message)
        {
            this.message = message;
        }
        public override MessageHeaders Headers
        {
            get { return this.message.Headers; }
        }
        public override MessageProperties Properties
        {
            get { return this.message.Properties; }
        }
        public override MessageVersion Version
        {
            get { return this.message.Version; }
        }
        protected override void OnWriteStartBody(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            this.message.WriteBodyContents(writer);
        }
        protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            writer.WriteAttributeString("xmlns", "oas", null, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            writer.WriteAttributeString("xmlns", "v2", null, "http://www.royalmailgroup.com/api/ship/V2");
            writer.WriteAttributeString("xmlns", "v1", null, "http://www.royalmailgroup.com/integration/core/V1");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");            
        }
    }
    public class RoyalMailMessageFormatter : IClientMessageFormatter
    {
        private readonly IClientMessageFormatter formatter;
        public RoyalMailMessageFormatter(IClientMessageFormatter formatter)
        {
            this.formatter = formatter;
        }
        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            var message = this.formatter.SerializeRequest(messageVersion, parameters);
            return new RoyalMailCustomMessage(message);
        }
        public object DeserializeReply(Message message, object[] parameters)
        {
            return this.formatter.DeserializeReply(message, parameters);
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class RoyalMailFormatMessageAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription,
            BindingParameterCollection bindingParameters)
        { }
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            var serializerBehavior = operationDescription.Behaviors.Find<XmlSerializerOperationBehavior>();
            if (clientOperation.Formatter == null)
                ((IOperationBehavior)serializerBehavior).ApplyClientBehavior(operationDescription, clientOperation);
          
            IClientMessageFormatter innerClientFormatter = clientOperation.Formatter;
            clientOperation.Formatter = new RoyalMailMessageFormatter(innerClientFormatter);
        }
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        { }
        public void Validate(OperationDescription operationDescription) { }
    }
