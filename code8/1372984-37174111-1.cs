    public class Models
    {
        public DocumentCreationInfo documentCreationInfo { get; set; }
    }
    
    public class DocumentCreationInfo
    {
        public List<FileInfo> fileInfos { get; set; }
        public string name { get; set; }
        public List<RecipientSetInfo> recipientSetInfos { get; set; }
        public string signatureType { get; set; }
        public string signatureFlow { get; set; }
    }
    
    public class FileInfo
    {
        public string transientDocumentId { get; set; }
    }
    
    public class RecipientSetInfo
    {
        public List<RecipientSetMemberInfo> recipientSetMemberInfos { get; set; }
        public string recipientSetRole { get; set; }
    }
    
    public class RecipientSetMemberInfo
    {
        public string email { get; set; }
        public string fax { get; set; }
    }
