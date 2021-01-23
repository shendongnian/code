    namespace ConsoleAdmin.Models
    {
        [Table("ntf.tblNotification_ntf")]
        public class Notification : tblNotification_ntf
        {
            [Key]
            public new int notificationId { get; set; }
        }
    
        public class NotificationDbContext : DbContext
        {
            public NotificationDbContext(): base("name=bd_Soquij_logEntities") { }
    
            public DbSet<Notification> Notifications { get; set; }
        }
    }
