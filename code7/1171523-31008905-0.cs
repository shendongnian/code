    [MessageContract]
    public class UploadStreamMessage
    {
       [MessageHeader]
       public string fileName;
       [MessageBodyMember]
       public Stream fileContents;
    } 
