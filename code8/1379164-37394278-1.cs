    public class School
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int schoolId { get; set; }
        public virtual SchoolInfo SchoolInfo { get; set; }
    }
    public class SchoolInfo
    {
        [Key]
        public int schoolId { get; set; }
        public virtual School School { get; set; }
    }
