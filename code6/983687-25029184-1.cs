    public abstract class BasePerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Person : BasePerson
    {
        public Seller Seller { get; set; }
    }
    public class Seller : BasePerson
    {
        public decimal Comissao { get; set; }
        public Person Person { get; set; }
    }    
    public class AppContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configures one to one-or-zero relationship.
            modelBuilder.Entity<Seller>().HasRequired(x => x.Person).WithRequiredDependent(x => x.Seller);
        }
    }
