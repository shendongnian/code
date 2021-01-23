    public class DataModel : DbContext
    {
        /* more code ... */
    
        public virtual DbSet<User> Users { get; set; }
        /* more code ... */
    }
