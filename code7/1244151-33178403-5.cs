    public class MyContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public override int SaveChanges()
        {
            foreach (var profile in ChangeTracker.Entries<Profile>()
                .Where(x => x.State == EntityState.Added))
            {
                profile.Entity.Resource = new Resource();
            }
             
            //Here you also need to do the same thing for other Entities that need a row in the Resources table (e.g. Organizations)
           
            return base.SaveChanges();
        }
    }
