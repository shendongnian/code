    class XsdValidationInspector : IClientMessageInspector
    {
        private readonly XmlSchemaSet _schemas;
    
        public XsdValidationInspector(XmlSchemaSet schemas)
        {
            this._schemas = schemas;
        }
    
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // Buffer the message so we can read multiple times.
            var buffer = reply.CreateBufferedCopy();
    
            // Validate the message content.
            var message = buffer.CreateMessage();
    
            using (var bodyReader
                = message.GetReaderAtBodyContents().ReadSubTree())
            {
                var settings = new XmlReaderSettings
                {
                    Schemas = this._schemas,
                    ValidationType = ValidationType.Schema,
                };
    
                var events = new List<ValidationEventArgs>();
                settings.ValidationEventHandler += (sender, e) => events.Add(e);
    
                using (var validatingReader
                    = XmlReader.Create(bodyReader, settings))
                {
                    // Read to the end of the body.
                    while(validatingReader.Read()) {  }
                }
    
                if (events.Any())
                {
                    // TODO: Examine events and decide whether to throw exception.
                }
            }
    
            // Assign a copy to be passed to the next component.
            reply = buffer.CreateMessage();
        }
    
        public object BeforeSendRequest(
            ref Message request,
            IClientChannel channel) {}
    }
