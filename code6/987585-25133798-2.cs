    public partial class Assignment
    {
        public Assignment()
        {
            this.CourseAvailables = new HashSet<CourseAvailable>();
        }
        [Key]
        private int _id; // Auto incremented id
        [NotMapped]
        public string AssignmentID
        {
            get
            {
                return "A" + _id.ToString("D5");
            }
        }
        public DateTime? SubmissionDate { get; set; }
        public string Status { get; set; }
        public decimal? Mark { get; set; }
        public string Comments { get; set; }
        public string FileLocation { get; set; }
        public virtual ICollection<CourseAvailable> CourseAvailables { get; set; }
    }
