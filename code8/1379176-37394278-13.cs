    public class SchoolInfo
    {
        [Key, ForeignKey("School")]
        public int schoolId { get; set; }
        public virtual School School { get; set; }
    }
