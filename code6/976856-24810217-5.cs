    public partial class MyClass
    {
        public string IdMyClass { get; set; }
        public string Name { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public ICollection<OtherClass> OtherClass { get; set; }
    }
    public partial class OtherClass
    {
        public int Id { get; set; }
        public string Stuff { get; set; }
    }
    public class MyContext : DbContext
    {
        public MyContext()
            : base("MyContextDb")
        {
        }
        public DbSet<MyClass> MyClasses { get; set; }
        public DbSet<OtherClass> OtherClasses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyClass>().ToTable("MyClass");
            modelBuilder.Entity<MyClass>()
                .HasKey(t => t.IdMyClass)
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<MyClass>().Property(t => t.IdMyClass).HasColumnName("IdMyClass");
            modelBuilder.Entity<MyClass>().Property(t => t.Name).HasColumnName("Name");
            modelBuilder.Entity<MyClass>().Property(t => t.ModificationDate).HasColumnName("ModificationDate");
        }
    }  
    
