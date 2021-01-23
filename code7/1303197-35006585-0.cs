    using Microsoft.Data.Entity;
    using System.Collections.Generic;
    public class SampleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
            // Visual Studio 2013 | Use the LocalDb 11 instance created by Visual Studio
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the name of the foreign key
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Tenant)
                .WithMany(t => t.Persons)
                .HasConstraintName("MyForeignKey");
            // Configure the name of a unique index
            modelBuilder.Entity<Person>().HasAlternateKey(p => p.Email).ForSqlServerHasName("MyUniqueEmail");
        }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
    public class Tenant
    {
        public Tenant()
        {
            Persons = new HashSet<Person>();
        }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
