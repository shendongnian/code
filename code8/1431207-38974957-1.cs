    public class RefTable {
        [Key]
        public int Id { get; set; }
        public string RefName { get; set; }
        public virtual ICollection<Data> DataDetails { get; set; }
    }
    public class Data {
        [Key]
        public int Id { get; set; }
        public int RefId { get; set; }
        [ForeignKey("RefId")]
        public virtual RefTable Machine { get; set; }
    }
    public class MyDbContext : DbContext {
        public MyDbContext()
            : base("name=CounterDbString") {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<RefTable>().HasMany(x => x.DataDetails).WithRequired(x => x.Machine);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<RefTable> RefData { get; set; }
        public DbSet<Data> Data { get; set; }
    }
