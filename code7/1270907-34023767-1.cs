    public class VideoPart {
        public Stream data {get;set;}
        public String Name {get;set;}
        public int VideoPartNumber {get;set;}
    }
    //then the server method signature would be
    //...
    public class VideoProcess : IVideoProcess
    {
        public void UploadVideo(VideoPart part, Guid ApplicatId, Guid TransactionCode)
        {
            // ... some process ...
        }
    }
