    public class Module
        {
           public int Id { get; set; }
           public string Name { get; set; }
           public ICollection<Resource> Resources { get; set; }
           public int? SpecialResourceId { get; set; }
           public Resource SpecialResource { get; set; }
        }
    
        public class Resource
        {
            public int Id { get; set; }
            public int? ModuleId { get; set; }
            public Module Module { get; set; }
            public virtual Module IsSpecialForModule { get; set; }
        }
    
        public class MyContext : DbContext
        {
            public virtual DbSet<Module> Modules { get; set; }
            public virtual DbSet<Resource> Resources { get; set; }
    
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
               modelBuilder.Entity<Module>()
                    .HasMany(x=>x.Resources)
                    .WithOptional(x=>x.Module)
                    .HasForeignKey(x=>x.ModuleId)
                    .WillCascadeOnDelete(false);
    
                modelBuilder.Entity<Resource>()
                    .HasOptional(x=>x.IsSpecialForModule)
                    .WithOptionalDependent(x=>x.SpecialResource)
                    .WillCascadeOnDelete(false);
            }
        }
