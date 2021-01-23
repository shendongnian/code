    [MessageContract]
    public class DocumentDescription
    {
        [MessageBodyMember(Namespace = "http://example.com/App")]
        public Stream Stream { get; set; }
    }
    Configure your binding this way
    
    <binding name="Binding_DocumentService" receiveTimeout="03:00:00"
            sendTimeout="02:00:00" transferMode="Streamed" maxReceivedMessageSize="2000000">
        <security mode="Transport" />
    </binding>
