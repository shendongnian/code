    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SampleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
