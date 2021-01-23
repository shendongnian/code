    public class MyContext : DbContext
    {
        public DbSet<Mammal> Mammals { get; set; }
        public DbSet<Dog>    Dogs    { get; set; }
        public DbSet<Bat>    Bats    { get; set; }
    }
