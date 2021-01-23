        public class TestContext : DbContext
        {
            public DbSet<TestEntity1> TestEntities1 { get; set; }
            public DbSet<TestEntity2> TestEntities2 { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new TestEntity1Configuration());
                modelBuilder.Configurations.Add(new TestEntity2Configuration());
                base.OnModelCreating(modelBuilder);
            }
        }
        public class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
        {
            public BaseEntityConfiguration()
            {
                HasKey(d => d.Id).Property(d => d.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            }
        }
        public class TestEntity1Configuration : BaseEntityConfiguration<TestEntity1> { 
            //your configuration here.
        }
        public class TestEntity2Configuration : BaseEntityConfiguration<TestEntity2> {
            //your configuration here.
        }
