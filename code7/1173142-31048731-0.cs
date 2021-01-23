    public class IssueVM
    {
        [Key] 
        public int ID { get; set; }
    
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Project Number")]
        public int ProjectID { get; set; }
    
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Issue Definition")]
        public string Description { get; set; }
    
        //... removed for brevity
    
        //Navigation Properties:
        public virtual ICollection<FileAttachment> FileAttachments { get; set; }
    }
    public class IssueDM : IssueVM
    {
        // Other Fields
    }
