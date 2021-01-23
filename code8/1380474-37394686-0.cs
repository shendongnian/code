    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        public virtual SchoolInfo SchoolInfo { get; set; }
    }
    public class SchoolInfo
    {
        [ForeignKey("School")]
        public int Id { get; set; }
        public virtual School School { get; set; }
    }
