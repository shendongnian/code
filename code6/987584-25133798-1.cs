    public partial class Assignment
    {
        public Assignment()
        {
            this.CourseAvailables = new HashSet<CourseAvailable>();
        }
    
        private static int _autoIncrementID = 0;
        private string _assignmentID = null;
    
    
        public string AssignmentID 
        {
            get
            {
                if (_assignmentID == null)
                {
                    _assignmentID = "A" + _autoIncrementID.ToString("D5");
                    _autoIncrementID++;
                }
    
                return _assignmentID;
            }
        }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Mark { get; set; }
        public string Comments { get; set; }
        public string FileLocation { get; set; }
    
        public virtual ICollection<CourseAvailable> CourseAvailables { get; set; }
    }
