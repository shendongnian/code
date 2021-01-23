    public partial class CPContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set;}
        public CPContext()
            : base("name=CPContext")
        {
        }
