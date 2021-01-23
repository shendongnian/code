    public class ViewDataUploadFilesResult
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int Length { get; set; }
        public HttpPostedFileBase FileObj { get; set; }
        public byte[] Content { get; set; }
    }
