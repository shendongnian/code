    [MetadataType(typeof(IssueMetadata))]
    public partial class IssueViewModel
    {
          //...
          public int ProjectID { get; set; }
          public string Description { get; set; }
          //...
    }
    [MetadataType(typeof(IssueMetadata))]
    public partial class Issue
    {
          [Key] 
          public int ID { get; set; }
          public int ProjectID { get; set; }
          public string Description { get; set; }
          //... removed for brevity
          //Navigation Properties:
          public virtual ICollection<FileAttachment> FileAttachments { get; set; }
    }
