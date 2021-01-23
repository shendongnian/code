    public class ApplicationUser : IdentityUser
    {
    
        public virtual ICollection<UserLog> UserLogs { get; set; }
    
    }
    
    public class UserLog
    {
        [Key]
        public Guid UserLogID { get; set; }
    
        public string IPAD { get; set; }
        public DateTime LoginDate { get; set; }
        public string UserId { get; set; }
    
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
    
    public System.Data.Entity.DbSet<UserLog> UserLog { get; set; }
