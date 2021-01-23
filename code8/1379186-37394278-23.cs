    public class SchoolInfo
    {
        [ForeignKey("School")]
        public int SchoolInfoId { get; set; }
        public virtual School School { get; set; }
    }
