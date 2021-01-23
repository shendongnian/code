    public class ReportFileRequest
    {
        public int ReportId { get; set; }
    
        public int FileRequestId { get; set;}
    
        public virtual Report Report { get; set;}
    
        public virtual FileRequest FileRequest { get; set; }
    }
