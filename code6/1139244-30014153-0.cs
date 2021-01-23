    public class Document {
        [Key]
        public int Id {get;set;}
       
        public List<DocumentVersion> DocumentVersions {get;set;}
    }
    public class DocumentVersion {
        [Key]
        public int Id {get;set;}
        [ForeignKey("Document")] 
        public int DocumentId {get;set;}
        
        public Document Document {get;set;}
    }
