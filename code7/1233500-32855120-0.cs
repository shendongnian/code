    public class AccountStartel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ClientID { get; set; }
        [Required]
        public int DbId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TimeZone { get; set; }
        [Required]
        public string AccountNum { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyGroup Company { get; set; }
        public virtual ICollection<UsageReport> UsageReports { get; set; }
        public AccountStartel() 
        {
            UsageReports = new List<UsageReport>();
        }
    }
