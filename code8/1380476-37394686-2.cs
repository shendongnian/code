    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId;
        public virtual IList<SchoolInfo> SchoolInfos { get; set; }
    }
    public class SchoolInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolInfoId { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
