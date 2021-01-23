    public class School
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int schoolId { get; set; }
        public virtual SchoolInfo SchoolInfo { get; set; }
    }
