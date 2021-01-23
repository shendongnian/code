    public class Model9Context : DbContext
    {
        public Model9Context(DbConnection connection)
            : base(connection, false)
        { }
        public DbSet<One> Ones { get; set; }
        public DbSet<Two> Twos { get; set; }
        public DbSet<Three> Threes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new OneMap());
            modelBuilder.Configurations.Add(new TwoMap());
            modelBuilder.Configurations.Add(new ThreeMap());
        }
    }
    public class One
    {
        public int Id { get; set; }
        public ICollection<Two> TwoList { get; set; }
    }
    public class Two
    {
        public int Id { get; set; }
        public int OneId { get; set; } 
        public virtual One One { get; set; }
        public virtual ICollection<Three> ThreeList { get; set; }
    }
    public class Three
    {
        public int Id { get; set; }
        public int TwoId { get; set; }
        public int OneId { get; set; }
        public virtual Two Two { get; set; }
    }
    public class OneMap : EntityTypeConfiguration<One>
    {
        public OneMap()
        {
            this.HasKey(t => t.Id);
            ToTable("One");
        }
    }
    public class TwoMap : EntityTypeConfiguration<Two>
    {
        public TwoMap()
        {
            this.HasKey(t => new { t.Id, t.OneId });
            ToTable("Two");
            
            HasRequired(t => t.One).WithMany(t => t.TwoList).HasForeignKey(t => t.OneId);
        }
    }
    public class ThreeMap : EntityTypeConfiguration<Three>
    {
        public ThreeMap()
        {
            HasKey(t => new { t.Id, t.OneId, t.TwoId });
            ToTable("Three");
            HasRequired(t => t.Two).WithMany(t => t.ThreeList).HasForeignKey(t => new {t.OneId, t.TwoId});
        }
    }
