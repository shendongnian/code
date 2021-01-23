    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId;
        public virtual SchoolInfo SchoolInfo { get; set; }
    }
    public class SchoolInfo
    {
        [ForeignKey("School")]
        public int SchoolInfoId { get; set; }
        public virtual School School { get; set; }
    }
