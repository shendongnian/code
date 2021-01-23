    public class MyDbContext : DbContext
    {
        public DbSet<ConstructionSite> ConstructionSites { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public MyDbContext()
            : base("YourConnectionStringName")
        {
        }
    }
    public class ConstructionSite
    {
        public Guid Id { get; set; }
        public int CreatorId { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Worker> Workers { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
    public class Manager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ConstructionSiteId { get; set; }
    }
    public class Worker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ConstructionSiteId { get; set; }
    }
