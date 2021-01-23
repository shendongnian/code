    public class PerfData
    {
        public Guid Id { get; set; }    
        public AttachmentData Attachment { get; set; } //navigation property
    }
    
    public class AttachmentData {
       ... 
       public Guid Id { get; set;}
       public PerfData Perf { get; set; } // navigation property
    }
