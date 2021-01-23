    [Route("/api/upload", Verbs = "POST")]
    public class UploadRequest: IReturn<UploadResponse>
    {
         public byte[] Data { get; set; }
    }
    public class UploadResponse
    {
        public ResponseStatus Response { get; set; }
    }
