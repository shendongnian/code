    public class SchoolInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int schoolInfoId { get; set; }
        [ForeignKey("School")]
        public int schoolId { get; set; }
        public virtual School School { get; set; }
    }
    // Relationship:
    modelBuilder.Entity<School>().HasOptional(a => a.SchoolInfo).WithRequired(a => a.School);
