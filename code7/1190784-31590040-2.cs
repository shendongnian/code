    public class Job
    {
        [Key]
        [Display(Name="Job ID")]
        public int JobID { get; set; }
        [Display(Name = "Job Type")]
        public int JobTypesID
        {
            get;
            set;
        }
    
        public IEnumerable<SelectListItem> JobTypeItems
        {
            get; set;
        }
    }
