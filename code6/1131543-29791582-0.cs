    [ServiceContract]
    public interface IVO_Upload
    {
                    [OperationContract]
                    string UploadFile(RemoteFileInfo request);
    }
    
    [MessageContract]
        public class RemoteFileInfo : IDisposable
        {
            [MessageHeader(MustUnderstand = true)]
            public string FileName;
            [MessageHeader(MustUnderstand = true)]
            public long Length;
            [MessageHeader(MustUnderstand = true)]
            public string Response;
    
            [MessageBodyMember(Order = 1)]
            public System.IO.Stream FileByteStream;
    
            public void Dispose()
            {
                if (FileByteStream != null)
                {
                    FileByteStream.Close();
                    FileByteStream = null;
                }
            }
        }
                
