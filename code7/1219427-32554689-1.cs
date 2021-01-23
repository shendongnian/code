    namespace EFCodeFirst.DataModel
    {
        public partial class Entities : DbContext
        {
            //EntitiesOracle -> Name of the connection String
            public Entities()
                : base("name=EntitiesOracle")
            {
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //For Oracle is neccesary
                modelBuilder.HasDefaultSchema("SCHEMA_NAME");
            }
    
            public DbSet<T_TABLE> T_TABLE { get; set; }
        }
    }
