    public class MyClass : DbContext
    {
        public DbSet<ExampleClass> Examples { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
    }
