    public class CompanyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasRequired(c => c.TimeZone)
                .WithMany()
                .HasForeignKey(c => c.TimeZoneId);
            base.OnModelCreating(builder);
        }
         
    }
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public int TimeZoneId { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        // this will be navigation property
        public TimeZone TimeZone { get; set; }
    }
    [Table("TimeZone")]
    public class TimeZone
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
