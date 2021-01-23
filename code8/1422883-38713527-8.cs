    public interface INameIsAlwaysUpperCase
    {
        string Name {get;set;}
    }
        
    public MyCustomContext : DbContext
    {    
        // Other stuff...
    
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<INameIsAlwaysUpperCase>())
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    // Possibly check for null or if it's changed at all.
                    entry.Entity.Name = entry.Entity.Name.ToUpper();
                }
            }
            return base.SaveChanges();
        }
    }
