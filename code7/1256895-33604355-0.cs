    public class EDentalCADBContext : DbContext {
        public DbSet<NotificationItem> NotificationItems { get; set; }
        public DbSet<User> Users { get; set; }
        
        public EDentalCADBContext(string connectionNameOrString) :
            base(connectionStringOrName) {
        }
    }
