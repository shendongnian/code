    public class Warehouse
    {
        public Int32 Id { get; set; }
        public String WarehouseCode { get; set; }
        public String Description { get; set; }
        [InverseProperty("LocationWarehouses")]
        public virtual ICollection<Location> LocationsWithThisWarehouse{ get; set; }
    }
    public class Location
    {
        public Int32 Id { get; set; }
        public String LocationCode { get; set; }
        public String Description { get; set; }
        public String WarehouseCode { get; set; }
        [InverseProperty("LocationsWithThisWarehouse")]
        public virtual Icollection<Warehouse> LocationWarehouses { get; set; }
    }
    public class YourContext: DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer < YourContext > (null);
            modelBuilder.Entity<Warehouse>().ToTable("Warehouse", "SchemaName");
            modelBuilder.Entity<Location>().ToTable("Location", "SchemaName");
            modelBuilder.Entity<Warehouse>().HasMany(g => g.LocationsWithThisWarehouse).WithMany(t => t.LocationWarehouses).Map(m =>
            {
                m.MapLeftKey("WarehouseCodeOnWarehouse");
                m.MapRightKey("WarehouseCodeOnLocation");
                m.ToTable("WarehouseAtLocation");
            });
        }
    }
