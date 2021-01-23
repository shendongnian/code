    [MessageContract]
    public class UploadStreamMessage
    {
       [MessageHeader]
       public string appRef;
       [MessageBodyMember]
       public Stream data;
    } 
