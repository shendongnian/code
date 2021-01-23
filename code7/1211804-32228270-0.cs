        public interface IPortalContext : IDisposable
        {
            DbSet<User> Users { get; }
            DbContext Context { get; }
        }
        public class PortalContext : DbContext, IPortalContext
        {
            public PortalContext()
                : base("PortalConnectionString")
            {
            }
            public virtual DbSet<User> Users { get; set; }
        }
