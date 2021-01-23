    public partial class IssueMetadata
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Project Number")]
        public int ProjectID { get; set; }
    
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Issue Definition")]
        public string Description { get; set; }
    }
