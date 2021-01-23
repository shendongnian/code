    public class EntityPOCO {
        public int Id { get; set; }
    
        public static OnModelCreating(DbModelBuilder builder) {
            builder.HasKey<EntityPOCO>(x => x.Id);
        }
    }
    ...
    
    public class EntityContext : DbContext {
       public DbSet<EntityPOCO> EntityPOCOs { get; set; }
       protected override void OnModelCreating(DbModelBuilder modelBuilder) {
          base.OnModelCreating(modelBuilder);
          EntityPOCO.OnModelCreating(modelBuilder);
       }
    }
