    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class Foo : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Bar> Bars { get; set; }
    }
    public class Bar : BaseEntity
    {
        public string Name { get; set; }
        public int FooId { get; set; }
        public Foo Foo { get; set; }
    }
    public class AppContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Registers and configures it first.
            DbInterception.Add(new FilterInterceptor());
            var softDeleteFilter = FilterConvention.Create<BaseEntity>("SoftDelete", 
                e => e.IsDeleted == false); // don't change it into e => !e.IsDeleted
            modelBuilder.Conventions.Add(softDeleteFilter);
        }
    }
