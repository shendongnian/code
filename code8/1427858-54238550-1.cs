     public class LoggingMessageInspector : IClientMessageInspector
    {
        public LoggingMessageInspector(ILogger<LoggingMessageInspector> logger)
        {
            Logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }
        public ILogger<LoggingMessageInspector> Logger { get; }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            using (var buffer = reply.CreateBufferedCopy(int.MaxValue))
            {
                var document = GetDocument(buffer.CreateMessage());
                Logger.LogTrace(document.OuterXml);
                reply = buffer.CreateMessage();
            }
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            using (var buffer = request.CreateBufferedCopy(int.MaxValue))
            {
                var document = GetDocument(buffer.CreateMessage());
                Logger.LogTrace(document.OuterXml);
                request = buffer.CreateMessage();
                return null;
            }
        }
        private XmlDocument GetDocument(Message request)
        {
            XmlDocument document = new XmlDocument();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // write request to memory stream
                XmlWriter writer = XmlWriter.Create(memoryStream);
                request.WriteMessage(writer);
                writer.Flush();
                memoryStream.Position = 0;
                // load memory stream into a document
                document.Load(memoryStream);
            }
            return document;
        }
    }
